using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationDiplom.Classes
{
    /*
     * Настройки генетического алгоритма оптимизации.
     * Все свойства имеют значения по умолчанию.
     */
    public class GAConfiguration
    {
        public int PopulationSize { get; set; } = 60;
        public int Generations { get; set; } = 100;
        public double SelectionProbability { get; set; } = 0.8;
        public double MutationProbabilityPerGene { get; set; } = 0.15;
        public int ElitismCount { get; set; } = 2;                          // Количество лучших для сохранения в новых хромосомах
        public int TournamentSize { get; set; } = 2;                        // Сколько случайных особей соревнуются за право стать родителем
        public int MaxMigrations { get; set; } = 10;                        // Максимальное допустимое количество миграций
        public double GlobalLoadLimit { get; set; } = 0.80;                 // Процент максимальной нагрузки серверов
        public double CapacityPenaltyWeight { get; set; } = 10000.0;
        public double MigrationPenaltyWeight { get; set; } = 10000.0;
        public int? RandomSeed { get; set; } = null;                        // Сид для воспроизводимости резульаттов
        public int ProgressUpdateInterval { get; set; } = 0;                // Отладка
    }
}
