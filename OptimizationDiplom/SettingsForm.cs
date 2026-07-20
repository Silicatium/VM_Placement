using OptimizationDiplom.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizationDiplom
{
    public partial class SettingsForm : Form
    {
        private readonly GAConfiguration _cfg;

        public SettingsForm(GAConfiguration config)
        {
            _cfg = config;
            InitializeComponent();
            LoadValues();

            // Setup Buttons
            btnSave.Click += (s, e) => { SaveValues(); DialogResult = DialogResult.OK; Close(); };
            btnCancel.Click += (s, e) => Close();
        }

        // Загрузка значений из конфигурации в элементы интерфейса
        private void LoadValues()
        {
            nudPopSize.Value = _cfg.PopulationSize;
            nudGenerations.Value = _cfg.Generations;
            nudSelectionProb.Value = (decimal)_cfg.SelectionProbability;
            nudMutationProb.Value = (decimal)_cfg.MutationProbabilityPerGene;
            nudElitism.Value = _cfg.ElitismCount;
            nudTournament.Value = _cfg.TournamentSize;
            nudMaxMig.Value = _cfg.MaxMigrations;
            nudLoadLimit.Value = (decimal)_cfg.GlobalLoadLimit;
            nudCapPen.Value = (decimal)_cfg.CapacityPenaltyWeight;
            nudMigPen.Value = (decimal)_cfg.MigrationPenaltyWeight;
            //nudProgressInt.Value = _cfg.ProgressUpdateInterval;
            if (_cfg.RandomSeed.HasValue) nudSeed.Value = _cfg.RandomSeed.Value;
        }

        // Сохранение значений из интерфейса обратно в конфигурацию
        private void SaveValues()
        {
            _cfg.PopulationSize = (int)nudPopSize.Value;
            _cfg.Generations = (int)nudGenerations.Value;
            _cfg.SelectionProbability = (double)nudSelectionProb.Value;
            _cfg.MutationProbabilityPerGene = (double)nudMutationProb.Value;
            _cfg.ElitismCount = (int)nudElitism.Value;
            _cfg.TournamentSize = (int)nudTournament.Value;
            _cfg.MaxMigrations = (int)nudMaxMig.Value;
            _cfg.GlobalLoadLimit = (double)nudLoadLimit.Value;
            _cfg.CapacityPenaltyWeight = (double)nudCapPen.Value;
            _cfg.MigrationPenaltyWeight = (double)nudMigPen.Value;
            //_cfg.ProgressUpdateInterval = (int)nudProgressInt.Value;
            _cfg.RandomSeed = (int)nudSeed.Value > 0 ? (int?)nudSeed.Value : null;
        }
    }
}
