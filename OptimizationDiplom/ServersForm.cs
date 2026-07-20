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
    public partial class ServersForm : Form
    {
        public List<Server> UpdatedServers { get; private set; }
        private readonly List<Server> _originalServers;
        private List<ServerBindable> _bindableList;

        public ServersForm(List<Server> servers)
        {
            _originalServers = servers ?? new List<Server>();
            InitializeComponent();
            SetupGrid();

            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        //Настройка DataGridView
        private void SetupGrid()
        {
            dgvServers.AutoGenerateColumns = false;
            dgvServers.AllowUserToAddRows = false;
            dgvServers.AllowUserToDeleteRows = true;
            dgvServers.ReadOnly = false;

            colId.DataPropertyName = "Id";
            colCpuCap.DataPropertyName = "CpuCap";
            colRamCap.DataPropertyName = "RamCap";
            colDiskCap.DataPropertyName = "DiskCap";
            colEIdle.DataPropertyName = "EIdle";
            colEMax.DataPropertyName = "EMax";

            // Конвертация из нередактируемых данных в редактируемые
            _bindableList = _originalServers.Select(s => new ServerBindable
            {
                Id = s.Id,
                CpuCap = s.CpuCap,
                RamCap = s.RamCap,
                DiskCap = s.DiskCap,
                EIdle = s.EIdle,
                EMax = s.EMax
            }).ToList();

            dgvServers.DataSource = null;
            dgvServers.DataSource = _bindableList;
        }

        // Добавление нового сервера с нулевыми параметрами
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int maxId = _bindableList.Any() ? _bindableList.Max(x => x.Id) : -1;
            _bindableList.Add(new ServerBindable
            {
                Id = maxId + 1,
                CpuCap = 0,
                RamCap = 0,
                DiskCap = 0,
                EIdle = 0,
                EMax = 0
            });

            dgvServers.DataSource = null;
            dgvServers.DataSource = _bindableList;

            // Авто-переход к новой строке и включение режима редактирования
            int idx = dgvServers.Rows.Count - 1;
            if (idx >= 0 && idx < dgvServers.Rows.Count)
            {
                dgvServers.FirstDisplayedScrollingRowIndex = idx;
                dgvServers.CurrentCell = dgvServers.Rows[idx].Cells["colCpuCap"];
                dgvServers.BeginEdit(true);
            }
        }

        // Сохранение/применение изменений
        private void BtnSave_Click(object sender, EventArgs e)
        {
            dgvServers.EndEdit();
            var errors = new List<string>();
            foreach (DataGridViewRow row in dgvServers.Rows)
            {
                if (row.IsNewRow || row.Cells["colId"].Value == null) continue; // Пропуск служебных строк

                // Валидация данных
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                if (row.Cells["colCpuCap"].Value == null || Convert.ToDouble(row.Cells["colCpuCap"].Value) <= 0)
                    errors.Add($"Сервер #{id}: CPU должен быть > 0");
                if (row.Cells["colRamCap"].Value == null || Convert.ToDouble(row.Cells["colRamCap"].Value) <= 0)
                    errors.Add($"Сервер #{id}: RAM должен быть > 0");
                if (row.Cells["colDiskCap"].Value == null || Convert.ToDouble(row.Cells["colDiskCap"].Value) <= 0)
                    errors.Add($"Сервер #{id}: Disk должен быть > 0");
            }

            // Показ ошибок
            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors.Take(5)), "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Конвертация обратно в неизменяемые объекты Server
            UpdatedServers = _bindableList
                .Where(b => b != null && b.Id >= 0)
                .Select(b => new Server(b.Id, b.CpuCap, b.RamCap, b.DiskCap, b.EIdle, b.EMax))
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        // Удаление выделенного сервера
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверка присутствия выделенной строки
            if (dgvServers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Сервера отсутствуют", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получение ID удаляемого сервера
            var selectedRow = dgvServers.SelectedRows[0];
            if (selectedRow.Cells["colId"].Value == null) return;

            int id = Convert.ToInt32(selectedRow.Cells["colId"].Value);

            // Подтверждение удаления
            var result = MessageBox.Show($"Удалить сервер #{id}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Удаление из списка и обновление сетки
            _bindableList.RemoveAll(b => b.Id == id);
            dgvServers.DataSource = null;
            dgvServers.DataSource = _bindableList;
        }
    }

    // Вспомогательный класс для привязки данных к DataGridView.
    public class ServerBindable
    {
        public int Id { get; set; }
        public double CpuCap { get; set; }
        public double RamCap { get; set; }
        public double DiskCap { get; set; }
        public double EIdle { get; set; }
        public double EMax { get; set; }
    }
}
