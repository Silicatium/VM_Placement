using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationDiplom.Classes
{
    /* 
     * Оптимизатор размещения виртуальных машин на физических серверах
     * с использованием генетического алгоритма (ГА).
     * 
     * Хромосома = массив int[], где индекс = ID ВМ, значение = ID сервера.
     * Фитнес-функция = энергопотребление + штрафы за перегрузку и миграции.
     */
    public class VMPlacementOptimizer
    {
        private readonly List<VirtualMachine> _vms;
        private readonly List<Server> _servers;
        private readonly int[] _currentPlacement;
        private readonly GAConfiguration _cfg;
        private readonly Random _rand;

        public VMPlacementOptimizer(List<VirtualMachine> vms, List<Server> servers,
                                    int[] currentPlacement, GAConfiguration cfg)
        {
            _vms = vms; _servers = servers; _currentPlacement = currentPlacement;
            _cfg = cfg;
            _rand = cfg.RandomSeed.HasValue ? new Random(cfg.RandomSeed.Value) : new Random();
        }

        // Создаёт начальную популяцию случайных решений
        private List<int[]> InitializePopulation()
        {
            var pop = new List<int[]>(_cfg.PopulationSize);

            // Добавление текущей раскладки как первую хромосому
            if (_currentPlacement != null && _currentPlacement.Length == _vms.Count)
                pop.Add((int[])_currentPlacement.Clone());

            for (int i = pop.Count; i < _cfg.PopulationSize; i++)
            {
                var chrom = new int[_vms.Count];
                for (int j = 0; j < chrom.Length; j++)
                    chrom[j] = _rand.Next(0, _servers.Count);
                pop.Add(chrom);
            }
            return pop;
        }

        // Расчет стоимости для определённой хромосомы
        private (double totalCost, double pureEnergy, int migrations, bool feasible) CalculateCost(int[] chrom)
        {
            double energy = 0.0;
            double penalty = 0.0;
            int migrations = 0;

            // Агрегирование нагрузки на каждый сервер: (CPU, RAM, Disk, кол-во ВМ)
            var loads = _servers.Select(_ => (Cpu: 0.0, Ram: 0.0, Disk: 0.0, Count: 0)).ToArray();

            // Распределение ВМ по серверам и счет миграций
            for (int i = 0; i < chrom.Length; i++)
            {
                int srv = chrom[i];
                loads[srv].Cpu += _vms[i].Cpu;
                loads[srv].Ram += _vms[i].Ram;
                loads[srv].Disk += _vms[i].Disk;
                loads[srv].Count++;

                if (chrom[i] != _currentPlacement[i])
                    migrations++;
            }

            double lim = _cfg.GlobalLoadLimit;

            // Рачет энергии и штрафа для каждого сервера
            for (int j = 0; j < _servers.Count; j++)
            {
                if (loads[j].Count == 0) continue; // Пустые сервера

                var srv = _servers[j];
                double utilCpu = loads[j].Cpu / srv.CpuCap;
                energy += srv.EIdle + (srv.EMax - srv.EIdle) * utilCpu;

                if (loads[j].Cpu > srv.CpuCap * lim)
                    penalty += (loads[j].Cpu - srv.CpuCap * lim) * _cfg.CapacityPenaltyWeight;
                if (loads[j].Ram > srv.RamCap * lim)
                    penalty += (loads[j].Ram - srv.RamCap * lim) * _cfg.CapacityPenaltyWeight;
                if (loads[j].Disk > srv.DiskCap * lim)
                    penalty += (loads[j].Disk - srv.DiskCap * lim) * _cfg.CapacityPenaltyWeight;
            }

            if (migrations > _cfg.MaxMigrations)
                penalty += (migrations - _cfg.MaxMigrations) * _cfg.MigrationPenaltyWeight;

            //int activeServers = loads.Count(l => l.Count > 0);

            return (energy + penalty, energy, migrations, penalty == 0 && migrations <= _cfg.MaxMigrations);
        }

        // Выбор лучших хромосом из случайной подвыборки
        private int[] SelectBestTournament(List<int[]> population, double[] costs)
        {
            int bestIdx = -1;
            double bestCost = double.MaxValue;

            for (int i = 0; i < _cfg.TournamentSize; i++)
            {
                int idx = _rand.Next(0, population.Count);
                if (costs[idx] < bestCost)
                {
                    bestCost = costs[idx];
                    bestIdx = idx;
                }
            }
            return (int[])population[bestIdx].Clone();
        }

        // Оператор селекции
        private (int[] c1, int[] c2) Crossover(int[] p1, int[] p2)
        {
            var c1 = (int[])p1.Clone();
            var c2 = (int[])p2.Clone();
            if (_rand.NextDouble() > _cfg.SelectionProbability) return (c1, c2);

            for (int i = 0; i < c1.Length; i++)
                if (_rand.NextDouble() < 0.5) (c1[i], c2[i]) = (c2[i], c1[i]);

            return (c1, c2);
        }

        // Оператор мутации
        private void Mutate(int[] chrom)
        {
            for (int i = 0; i < chrom.Length; i++)
                if (_rand.NextDouble() < _cfg.MutationProbabilityPerGene)
                {
                    //if (_rand.NextDouble() < 0.5)
                    //{
                    //    int randomVmIndex = _rand.Next(chrom.Length);
                    //    chrom[i] = chrom[randomVmIndex];
                    //}
                    //else
                    //{
                    //    chrom[i] = _rand.Next(_servers.Count);
                    //}
                    chrom[i] = _rand.Next(_servers.Count);
                }
        }

        // Оператор локального улучшения
        private void ApplyConsolidation(int[] chrom)
        {
            // Группировка ВМ по серверам
            var serverVms = new List<int>[_servers.Count];
            for (int s = 0; s < _servers.Count; s++) serverVms[s] = new List<int>();
            for (int i = 0; i < chrom.Length; i++)
                if (chrom[i] >= 0 && chrom[i] < _servers.Count) serverVms[chrom[i]].Add(i);

            // Сортировка серверов по загрузке CPU (по убыванию)
            var sortedServers = Enumerable.Range(0, _servers.Count)
                .OrderByDescending(s => serverVms[s].Sum(idx => _vms[idx].Cpu))
                .ToList();

            // "Слабые" серверы (нижние 30%) -> ВМ с них будет происходить перенос
            var weakServers = sortedServers.Skip((int)(_servers.Count * 0.7)).ToList();
            // "Целевые" серверы (верхние 70%) -> куда будет происходить упаковка
            var targetServers = sortedServers.Take((int)(_servers.Count * 0.7)).ToList();

            var vmsToMove = new List<int>();
            foreach (var srv in weakServers) vmsToMove.AddRange(serverVms[srv]);

            //  Текущие загрузки целевых серверов
            var loads = new (double C, double R, double D)[_servers.Count];
            foreach (var srv in targetServers)
            {
                foreach (var idx in serverVms[srv])
                {
                    loads[srv].C += _vms[idx].Cpu;
                    loads[srv].R += _vms[idx].Ram;
                    loads[srv].D += _vms[idx].Disk;
                }
            }

            // Жадное размещение ВМ со слабых узлов
            foreach (var vmIdx in vmsToMove)
            {
                var vm = _vms[vmIdx];
                bool placed = false;
                foreach (var srv in targetServers)
                {
                    double limit = _cfg.GlobalLoadLimit;
                    if (loads[srv].C + vm.Cpu <= _servers[srv].CpuCap * limit &&
                        loads[srv].R + vm.Ram <= _servers[srv].RamCap * limit &&
                        loads[srv].D + vm.Disk <= _servers[srv].DiskCap * limit)
                    {
                        chrom[vmIdx] = srv;
                        loads[srv].C += vm.Cpu;
                        loads[srv].R += vm.Ram;
                        loads[srv].D += vm.Disk;
                        placed = true;
                        break;
                    }
                }
                // Если не влезло никуда -> возврат на самый слабый сервер
                if (!placed) chrom[vmIdx] = weakServers[0];
            }
        }

        // Вычисление энергии для раскладки
        public static double CalculateEnergy(List<VirtualMachine> vms, List<Server> servers, int[] placement)
        {
            double totalEnergy = 0;
            var loads = servers.Select(_ => 0.0).ToArray(); // Нагрузка CPU на каждый сервер

            // Агрегация нагрузки
            for (int i = 0; i < placement.Length && i < vms.Count; i++)
            {
                int srv = placement[i];
                if (srv >= 0 && srv < servers.Count)
                    loads[srv] += vms[i].Cpu;
            }

            // Применение формулы энергии
            for (int j = 0; j < servers.Count; j++)
            {
                if (loads[j] > 0) // Сервер включён только если на нём есть ВМ
                {
                    var srv = servers[j];
                    double utilCpu = Math.Min(loads[j] / srv.CpuCap, 1.0); // Ограничиваем 100%
                    totalEnergy += srv.EIdle + (srv.EMax - srv.EIdle) * utilCpu;
                }
            }

            return totalEnergy;
        }

        // Главынй цикл
        public (List<List<int>> bNew, double bestEnergy, int migrations, bool feasible) Run()
        {
            var population = InitializePopulation();
            int[] bestChrom = null;                       // Лучшая хромосома за все поколения
            double bestCost = double.MaxValue;            // Минимальная стоимость
            double bestEnergy = 0.0;                      // Чистая энергия лучшего решения
            int bestMigrations = 0;                       // Количество миграций в лучшем решении
            bool bestFeasible = false;                    // Допустимость лучшего решения

            // Оценка начальной популяции
            double[] costs = new double[population.Count];
            Parallel.For(0, population.Count, i =>
                costs[i] = CalculateCost(population[i]).totalCost);

            //Console.WriteLine("Запуск генетического алгоритма...");
            //Console.WriteLine($"Популяция: {_cfg.PopulationSize} | Поколений: {_cfg.Generations} | Лимит миграций: {_cfg.MaxMigrations}");
            //Console.WriteLine(new string('-', 60));

            // Основной цикл ГА
            for (int gen = 0; gen < _cfg.Generations; gen++)
            {
                // Лучшие хромосомы
                var eliteIndices = Enumerable.Range(0, population.Count)
                    .OrderBy(i => costs[i])
                    .Take(_cfg.ElitismCount)
                    .ToArray();

                var elite = eliteIndices.Select(i => (int[])population[i].Clone()).ToList();

                // Обновление глобального лучшего решения
                int currentBestIdx = Array.IndexOf(costs, costs.Min());
                if (costs[currentBestIdx] < bestCost)
                {
                    bestCost = costs[currentBestIdx];
                    bestChrom = (int[])population[currentBestIdx].Clone();
                    var res = CalculateCost(bestChrom);
                    bestEnergy = res.pureEnergy;
                    bestMigrations = res.migrations;
                    bestFeasible = res.feasible;
                }

                // Селекция, скрещивание, мутация
                var parents = Enumerable.Range(0, population.Count)
                    .Select(_ => SelectBestTournament(population, costs))
                    .ToList();
                var newPop = new List<int[]>(population.Count);
                for (int i = 0; i < population.Count - 1; i += 2)
                {
                    var (c1, c2) = Crossover(parents[i], parents[i + 1]);
                    Mutate(c1); Mutate(c2);
                    ApplyConsolidation(c1);
                    ApplyConsolidation(c2);
                    newPop.Add(c1); newPop.Add(c2);
                }
                if (newPop.Count < population.Count) newPop.Add((int[])parents.Last().Clone());

                // Обновление оценки
                double[] newCosts = new double[newPop.Count];
                Parallel.For(0, newPop.Count, i =>
                    newCosts[i] = CalculateCost(newPop[i]).totalCost);

                // Замена худших на лучших
                var worstIndices = Enumerable.Range(0, population.Count)
                    .OrderBy(i => newCosts[i])
                    .TakeLast(_cfg.ElitismCount)
                    .ToArray();
                for (int k = 0; k < _cfg.ElitismCount; k++)
                {
                    newPop[worstIndices[k]] = elite[k];
                    newCosts[worstIndices[k]] = costs[eliteIndices[k]];
                }

                population = newPop;
                costs = newCosts;

                // Отладка
                /*if (_cfg.ProgressUpdateInterval > 0 && (gen % _cfg.ProgressUpdateInterval == 0 || gen == _cfg.Generations - 1))
                {
                    string status = bestFeasible ? "Допустимо" : "Штраф";
                    Console.WriteLine($"Поколение {gen + 1,3}/{_cfg.Generations} | Мин. стоимость: {bestCost,9:F2} | Чистая энергия: {bestEnergy,9:F2} Вт | Миграций: {bestMigrations,2} | {status}");
                }*/
            }

            // Декодирование в B_new
            var bNew = Enumerable.Range(0, _servers.Count).Select(_ => new List<int>()).ToList();
            for (int i = 0; i < _vms.Count; i++)
                bNew[bestChrom[i]].Add(_vms[i].Id);

            Console.WriteLine(new string('-', 60));
            return (bNew, bestEnergy, bestMigrations, bestFeasible);
        }
    }
}
