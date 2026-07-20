using OptimizationDiplom.Classes;
using OptimizationDiplom.JsonStorage;

namespace OptimizationDiplom
{
    public partial class Form1 : Form
    {
        private readonly string _dataPath; // Путь к папке с данными (файлы JSON)
        private List<VirtualMachine> _vms = new();
        private List<Server> _servers = new();
        private int[] _currentPlacement = Array.Empty<int>();
        private GAConfiguration _config = new();
        private List<List<int>> _bNew;
        private double _bestEnergy;
        private int _bestMigrations;
        private bool _isFeasible;

        // Параметры отрисовки карточек серверов
        private const int CardW = 220;
        private const int CardH = 160;
        private const int Gap = 12;
        private bool _isUpdating = false;

        public Form1()
        {
            _dataPath = Path.Combine(Application.StartupPath, "Data");
            InitializeComponent();

            Directory.CreateDirectory(_dataPath);
            LoadData();

            this.Load += (s, e) => TriggerLayoutUpdate();
            this.Resize += (s, e) => TriggerLayoutUpdate();
            this.splitContainer1.SplitterMoved += (s, e) => TriggerLayoutUpdate();
        }

        // Безопасная перерисовка, предотвращает рекурсию и мерцание
        private void TriggerLayoutUpdate()
        {
            if (_isUpdating) return;  // Защита от повторного входа
            _isUpdating = true;
            try
            {
                // Приостановка перерисовки
                panelB.SuspendLayout();
                panelBNew.SuspendLayout();
                RenderCurrentPlacement();
                RenderOptimizedPlacement();
            }
            finally
            {
                // Возобновление перерисовки
                panelB.ResumeLayout();
                panelBNew.ResumeLayout();
                _isUpdating = false;
            }
        }

        // Конвертация массива раскладки из ID в индексы
        private int[] ConvertPlacementToIndices(int[] placementById)
        {
            // Создание словаря: Server.Id -> индекс в списке (0, 1, 2...)
            var idToIndex = new Dictionary<int, int>();
            for (int i = 0; i < _servers.Count; i++)
                idToIndex[_servers[i].Id] = i;

            var result = new int[placementById.Length];
            for (int i = 0; i < placementById.Length; i++)
            {
                int srvId = placementById[i];
                // Если ID найден — берем индекс, иначе — 0 (защита от ошибок)
                result[i] = idToIndex.TryGetValue(srvId, out int idx) ? idx : 0;
            }
            return result;
        }

        // Обратная конвертация
        private int[] ConvertResultToIds(List<List<int>> bNewByIndex)
        {
            var result = new int[_vms.Count];

            // Проход по всем серверам
            for (int srvIndex = 0; srvIndex < bNewByIndex.Count; srvIndex++)
            {
                int srvId = _servers[srvIndex].Id; // Получение реального ID сервера по его индексу

                // Для каждой ВМ на этом сервере записывается её сервер в результат
                foreach (int vmId in bNewByIndex[srvIndex])
                {
                    int vmIndex = _vms.FindIndex(v => v.Id == vmId);
                    if (vmIndex != -1)
                        result[vmIndex] = srvId;
                }
            }

            return result;
        }

        // Проверка на наличие дубликатов ID
        private bool HasDuplicateIds<T>(List<T> items, Func<T, int> getId, out string duplicateList)
        {
            var seen = new HashSet<int>();
            var duplicates = new HashSet<int>();
            foreach (var item in items)
            {
                int id = getId(item);
                if (!seen.Add(id)) // Add возвращает false, если ключ уже есть
                    duplicates.Add(id);
            }

            duplicateList = duplicates.Count > 0 ? string.Join(", ", duplicates) : string.Empty;
            return duplicates.Count > 0;
        }

        // Загрузка всех данный из JSON-файлов
        private void LoadData()
        {
            bool isValid = false;
            while (!isValid)
            {
                _config = Storage.LoadConfig(Path.Combine(_dataPath, "config.json"));
                _servers = Storage.LoadServers(Path.Combine(_dataPath, "servers.json"));
                _vms = Storage.LoadVMs(Path.Combine(_dataPath, "vms.json"));
                int[] rawPlacement = Storage.LoadPlacement(Path.Combine(_dataPath, "current_placement.json"));

                // Проверка на дубликаты ID
                bool hasServerDups = HasDuplicateIds(_servers, s => s.Id, out string serverDups);
                bool hasVmDups = HasDuplicateIds(_vms, v => v.Id, out string vmDups);

                if (hasServerDups || hasVmDups)
                {
                    string msg = "Ошибка: обнаружены дубликаты идентификаторов (ID).\n";
                    if (hasServerDups) msg += $"• Дублирующиеся ID серверов: {serverDups}\n";
                    if (hasVmDups) msg += $"• Дублирующиеся ID виртуальных машин: {vmDups}\n";
                    msg += "\nПожалуйста, исправьте файлы JSON в папке Data и нажмите «Повтор» для повторной загрузки.";

                    var result = MessageBox.Show(msg, "Ошибка загрузки", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result != DialogResult.Retry)
                    {
                        Environment.Exit(1);
                        return;
                    }
                    continue;
                }
                isValid = true;

                // Сортировка ВМ по ID для детерминированного порядка
                _vms = _vms.OrderBy(v => v.Id).ToList();

                // Быстрая проверки существования сервера
                var existingServerIds = new HashSet<int>(_servers.Select(s => s.Id));
                int defaultSrv = _servers.Any() ? _servers[0].Id : 0;

                // Сбор предупреждений для единого вывода
                var warnings = new List<string>();
                var invalidServerIds = new HashSet<int>();
                int missingEntries = 0;
                int extraEntries = 0;

                // Конвертация сырого массива в раскладку, привязанную к отсортированному списку
                _currentPlacement = new int[_vms.Count];
                for (int i = 0; i < _vms.Count; i++)
                {
                    if (i < rawPlacement.Length)
                    {
                        int srvId = rawPlacement[i];

                        // Проверка: существует ли такой сервер в списке?
                        if (existingServerIds.Contains(srvId))
                        {
                            // Сервер найден
                            _currentPlacement[i] = srvId;
                        }
                        else
                        {
                            // Сервер не найден
                            invalidServerIds.Add(srvId);
                            _currentPlacement[i] = defaultSrv;
                        }
                    }
                    else
                    {
                        // Записи в файле не хватает
                        missingEntries++;
                        _currentPlacement[i] = defaultSrv;
                    }
                }

                // Записей больше, чем ВМ
                if (rawPlacement.Length > _vms.Count)
                {
                    extraEntries = rawPlacement.Length - _vms.Count;
                }

                // Вывод предупреждений
                if (invalidServerIds.Count > 0 || missingEntries > 0 || extraEntries > 0)
                {
                    string warningMsg = "Предупреждение при загрузке раскладки:\n\n";

                    if (invalidServerIds.Count > 0)
                    {
                        warningMsg += $"• Найдены ссылки на несуществующие серверы (ID: {string.Join(", ", invalidServerIds)}).\n" +
                                     $"  Соответствующие ВМ назначены на сервер по умолчанию (ID={defaultSrv}).\n";
                    }
                    if (missingEntries > 0)
                    {
                        warningMsg += $"• В файле распределения не хватает {missingEntries} записей.\n" +
                                     $"  Недостающие ВМ назначены на сервер по умолчанию (ID={defaultSrv}).\n";
                    }
                    if (extraEntries > 0)
                    {
                        warningMsg += $"• В файле распределения обнаружено {extraEntries} лишних записей (больше, чем ВМ).\n" +
                                     $"  Эти данные проигнорированы. Проверьте целостность файлов.\n";
                    }

                    warningMsg += "\nПроверьте файлы JSON в папке Data.";
                    MessageBox.Show(warningMsg, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Синхронизация массива при первом запуске
                if (_currentPlacement.Length != _vms.Count)
                    Array.Resize(ref _currentPlacement, _vms.Count);
            }
        }

        // Сохранение данных в JSON-файлы
        private void SaveData()
        {
            try
            {
                Directory.CreateDirectory(_dataPath);

                Storage.SaveConfig(Path.Combine(_dataPath, "config.json"), _config);
                Storage.SaveServers(Path.Combine(_dataPath, "servers.json"), _servers);
                Storage.SaveVMs(Path.Combine(_dataPath, "vms.json"), _vms);

                int[] placementToSave = _currentPlacement;

                // Если была произведена оптимизация, то сохранение новой раскладки
                if (_bNew != null && _bNew.Count > 0)
                {
                    int[] newPlacement = ConvertResultToIds(_bNew);

                    // Обновление состояния программы
                    placementToSave = newPlacement;
                    _currentPlacement = newPlacement;
                    _bNew = null;
                }

                Storage.SavePlacement(Path.Combine(_dataPath, "current_placement.json"), placementToSave);
                TriggerLayoutUpdate();

                MessageBox.Show($"Сохранено в:\n{_dataPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Универсальный метод отрисовки сетки карточек серверов.
         * 
         * Параметры:
         * - target: панель, в которую рисуем (panelB или panelBNew)
         * - data: список кортежей (ID сервера, список ВМ на нём)
         * - showStatus: если true, подсвечиваются ВМ, которые переместились
         * 
         * Алгоритм:
         * 1. Вычисление, сколько колонок помещается в доступную ширину
         * 2. Расставление карточки по координатам (x, y) вручную
         * 3. Задание AutoScrollMinSize для включения прокрутки при необходимости
         */
        private void RenderGrid(Panel target, List<(int Id, List<int> Vms)> data, bool showStatus)
        {
            // Отстутсвие данных
            target.Controls.Clear();
            if (data.Count == 0)
            {
                target.Controls.Add(new Label
                {
                    Text = "Нет данных",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray
                });
                btnOptimize.Enabled = false;
                return;
            }
            else { btnOptimize.Enabled = true; }

                int usableWidth = target.ClientSize.Width - 24;
            if (usableWidth < CardW) usableWidth = CardW;

            int cols = Math.Max(1, usableWidth / (CardW + Gap)); // Сколько карточек помещается в ряд
            int x = 0, y = 0, colIdx = 0; // Координаты текущей карточки

            foreach (var item in data)
            {
                var card = CreateCard(item.Id, item.Vms, showStatus);
                card.Location = new Point(x, y);
                target.Controls.Add(card);

                // Сообщение о недопустимых карточках
                if (card.BackColor == Color.FromArgb(255, 220, 220))
                {
                    MessageBox.Show($"Сервер #{item.Id} в панели {target.Name} имеет недопустимые ВМ", "Предупреждение", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Переход к следующей позиции в сетке
                colIdx++;
                if (colIdx >= cols)
                {
                    colIdx = 0; // Новая строка
                    x = 0;
                    y += CardH + Gap;
                }
                else
                {
                    x += CardW + Gap; // Следующая колонка
                }
            }
            target.AutoScrollMinSize = new Size(usableWidth, y + CardH + Gap);
        }

        // Отрисовка левой панели: текущая раскладка из файла
        private void RenderCurrentPlacement()
        {
            panelB.Controls.Clear();
            panelB.AutoScrollMinSize = Size.Empty;

            // Группировка ВМ по серверам на основе _currentPlacement
            var data = _servers.Select(srv =>
            {
                var vmIds = _vms.Where((vm, i) => i < _currentPlacement.Length && _currentPlacement[i] == srv.Id)
                                .Select(vm => vm.Id).ToList();
                return (srv.Id, vmIds);
            }).OrderBy(x => x.Id).ToList();

            RenderGrid(panelB, data, false);

            // Обновление статистики: расчет энергии для текущей раскладки
            lblStatsOld.Text = $"Энергия: {VMPlacementOptimizer.CalculateEnergy(_vms, _servers, _currentPlacement):F1} Вт";
        }

        // Отрисовка правой панели: результат оптимизации
        private void RenderOptimizedPlacement()
        {
            panelBNew.Controls.Clear();
            panelBNew.AutoScrollMinSize = Size.Empty;

            // Если оптимизация ещё не запускалась — показ подсказки
            if (_bNew == null || _bNew.Count == 0)
            {
                lblStats.Text = "Нажмите \"Произвести перераспределение\"";
                lblStats.ForeColor = Color.Gray;
                return;
            }

            // Конвертация _bNew в формат для RenderGrid
            var data = Enumerable.Range(0, _servers.Count).Select(i => (i, _bNew[i])).ToList();
            RenderGrid(panelBNew, data, true);

            // Обновление статистики с цветом в зависимости от допустимости решения
            string status = _isFeasible ? "Допустимо" : "Есть штрафы";
            lblStats.Text = $"Энергия: {_bestEnergy:F1} Вт | Миграций: {_bestMigrations} | {status}";
            lblStats.ForeColor = _isFeasible ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);
        }

        // Создание карточки сервера
        private Panel CreateCard(int srvId, List<int> vmIds, bool isOpt)
        {
            var card = new Panel { Size = new Size(CardW, CardH), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, AutoSize = false };

            // Безопасное получение сервера
            var srv = _servers.FirstOrDefault(s => s.Id == srvId);

            // Отображение недопустимой карточки
            bool isOverloaded = false;
            if (srv != null && vmIds.Any())
            {
                double totalCpu = _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Cpu);
                double totalRam = _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Ram);
                double totalDisk = _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Disk);

                if (totalCpu > _config.GlobalLoadLimit * srv.CpuCap || totalRam > _config.GlobalLoadLimit * srv.RamCap ||
                     totalDisk > _config.GlobalLoadLimit * srv.DiskCap)
                    isOverloaded = true;
            }
            if (isOverloaded)
            {
                card.BackColor = Color.FromArgb(255, 220, 220);
            }

            // РАсчет суммарной загрузки CPU от всех ВМ на этом сервере
            double load = srv != null && vmIds.Any()
                ? _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Cpu) / srv.CpuCap * 100
                : 0;

            // Цвет прогресс-бара: зелёный (<70%), жёлтый (70-90%), красный (>90%)
            Color c = load < 70 ? Color.FromArgb(16, 185, 129) : load < 90 ? Color.FromArgb(245, 158, 11) : Color.FromArgb(239, 68, 68);

            // Заголовок карточки
            card.Controls.Add(new Label
            {
                Text = $"Сервер {srvId}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 8),
                Size = new Size(CardW - 20, 20)
            });

            // Фон прогресс-бара
            var barBg = new Panel
            {
                Location = new Point(10, 32),
                Size = new Size(CardW - 20, 6),
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // Заполнение прогресс-бара
            barBg.Controls.Add(new Panel
            {
                Size = new Size((int)((CardW - 20) * Math.Min(load, 100) / 100), 6),
                BackColor = c
            });
            card.Controls.Add(barBg);

            // Текст с процентом загрузки
            card.Controls.Add(new Label
            {
                Text = $"CPU: {load:F0}%",
                Location = new Point(10, 42),
                Size = new Size(CardW - 20, 18),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray
            });

            // Индикаторы RAM и Disk
            int indicatorsY = 62;          // Y-позиция для полосок
            int barH = 6;                  // Высота полоски
            int barW = (CardW - 20 - 10) / 2; // Ширина каждой полоски
            int labelH = 16;               // Высота текста под полоской

            // Индикатор RAM
            double ramLoad = srv != null && vmIds.Any()
                ? _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Ram) / srv.RamCap * 100
                : 0;
            Color ramColor = ramLoad < 70 ? Color.FromArgb(16, 185, 129) : ramLoad < 90 ? Color.FromArgb(245, 158, 11) : Color.FromArgb(239, 68, 68);

            // Фон полоски RAM
            var ramBg = new Panel
            {
                Location = new Point(10, indicatorsY),
                Size = new Size(barW, barH),
                BackColor = Color.FromArgb(226, 232, 240)  // Тот же светло-серый, что у CPU
            };

            // Заполнение полоски RAM
            ramBg.Controls.Add(new Panel
            {
                Size = new Size((int)(barW * Math.Min(ramLoad, 100) / 100), barH),
                BackColor = ramColor
            });
            card.Controls.Add(ramBg);

            // Текст под полоской RAM
            card.Controls.Add(new Label
            {
                Text = $"RAM: {ramLoad:F0}%",
                Location = new Point(10, indicatorsY + barH + 2),
                Size = new Size(barW, labelH),
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopLeft
            });

            // Индикатор Disk
            double diskLoad = srv != null && vmIds.Any()
                ? _vms.Where(v => vmIds.Contains(v.Id)).Sum(v => v.Disk) / srv.DiskCap * 100
                : 0;
            Color diskColor = diskLoad < 70 ? Color.FromArgb(16, 185, 129) : diskLoad < 90 ? Color.FromArgb(245, 158, 11) : Color.FromArgb(239, 68, 68);

            // Фон полоски Disk
            var diskBg = new Panel
            {
                Location = new Point(10 + barW + 10, indicatorsY),  // +10px отступ между полосками
                Size = new Size(barW, barH),
                BackColor = Color.FromArgb(226, 232, 240)
            };

            // Заполнение полоски Disk
            diskBg.Controls.Add(new Panel
            {
                Size = new Size((int)(barW * Math.Min(diskLoad, 100) / 100), barH),
                BackColor = diskColor
            });
            card.Controls.Add(diskBg);

            // Текст под полоской Disk
            card.Controls.Add(new Label
            {
                Text = $"Disk: {diskLoad:F0}%",
                Location = new Point(10 + barW + 10, indicatorsY + barH + 2),
                Size = new Size(barW, labelH),
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopLeft
            });

            int vmListY = indicatorsY + barH + labelH + 6;

            // Список ВМ: берутся первые 42, если больше — добавляется многоточие
            string vmText = vmIds.Any()
                ? $"ВМ: {string.Join(", ", vmIds.Take(42))}" + (vmIds.Count > 42 ? "..." : "")
                : "Выключен"; // Если на сервере нет ВМ
            var vmLbl = new Label
            {
                Text = vmText,
                Location = new Point(10, vmListY),
                Size = new Size(CardW - 20, CardH - vmListY - 12),
                Font = new Font("Segoe UI", 8.2f),
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft
            };

            // Подсветка миграций
            if (isOpt && _currentPlacement != null)
            {
                int moved = vmIds.Count(id =>
                {
                    var idx = _vms.FindIndex(v => v.Id == id);
                    return idx >= 0 && idx < _currentPlacement.Length && _currentPlacement[idx] != srvId;
                });
                if (moved > 0) vmLbl.ForeColor = Color.FromArgb(249, 115, 22);
            }
            card.Controls.Add(vmLbl);
            return card;
        }

        // Запуск оптимизации
        private async void btnOptimize_Click(object sender, EventArgs e)
        {
            // Блокировка кнопки на время выполнения
            btnOptimize.Enabled = false;
            btnOptimize.Text = "Выполняется...";

            // Запуск ГА в фоновом потоке, чтобы не блокировать интерфейс
            await Task.Run(() =>
            {
                int[] currentPlacementIndices = ConvertPlacementToIndices(_currentPlacement);
                var res = new VMPlacementOptimizer(_vms, _servers, currentPlacementIndices, _config).Run();
                _bNew = res.bNew; _bestEnergy = res.bestEnergy; _bestMigrations = res.migrations; _isFeasible = res.feasible;
            });
            TriggerLayoutUpdate();

            // Разблокировка кнопки
            btnOptimize.Enabled = true;
            btnOptimize.Text = "Произвести перераспределение";

            MessageBox.Show($"Готово!\nЭнергия: {_bestEnergy:F1} Вт | Миграций: {_bestMigrations}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Меню: Загрузить — перечитать файлы и сбросить результат оптимизации
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            _bNew = null;
            _bestEnergy = 0;
            _bestMigrations = 0;
            _isFeasible = false;
            TriggerLayoutUpdate();
        }

        // Меню: Сохранить
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => SaveData();

        // Меню: Настройки ГА
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => new SettingsForm(_config).ShowDialog();

        // Меню: Редактор ВМ
        private void vmEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохранение текущих привязок
            var vmIdToServer = new Dictionary<int, int>();
            for (int i = 0; i < Math.Min(_vms.Count, _currentPlacement.Length); i++)
                vmIdToServer[_vms[i].Id] = _currentPlacement[i];

            var f = new VmsForm(_vms);
            if (f.ShowDialog() == DialogResult.OK)
            {
                _vms = f.UpdatedVMs;

                // Перестраивание массива распределения на основе сохранённых привязок
                int defaultSrv = _servers.Any() ? _servers[0].Id : 0;
                _currentPlacement = new int[_vms.Count];

                for (int i = 0; i < _vms.Count; i++)
                {
                    // Если ВМ новая, назначение сервера по умолчанию
                    if (vmIdToServer.TryGetValue(_vms[i].Id, out int srvId))
                        _currentPlacement[i] = srvId;
                    else
                        _currentPlacement[i] = defaultSrv;
                }

                TriggerLayoutUpdate();
            }
        }

        // Меню: Редактор серверов
        private void serverEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new ServersForm(_servers);
            if (f.ShowDialog() == DialogResult.OK)
            {
                _servers = f.UpdatedServers;

                // Поиск ID первого доступного сервера
                int defaultSrv = _servers.Any() ? _servers[0].Id : 0;

                // Быстрая проверка существования сервера через HashSet
                var existingIds = new HashSet<int>(_servers.Select(s => s.Id));

                for (int i = 0; i < _currentPlacement.Length; i++)
                {
                    // Если старый сервер ВМ был удалён, переназначение на первый доступный
                    if (!existingIds.Contains(_currentPlacement[i]))
                        _currentPlacement[i] = defaultSrv;
                }
                TriggerLayoutUpdate();
            }
        }
    }
}
