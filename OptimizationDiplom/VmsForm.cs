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
    public partial class VmsForm : Form
    {
        public List<VirtualMachine> UpdatedVMs { get; private set; }
        private readonly List<VirtualMachine> _vms;
        private List<VmBindable> _bindableList;

        public VmsForm(List<VirtualMachine> vms)
        {
            _vms = vms ?? new List<VirtualMachine>();
            InitializeComponent();
            SetupGrid();

            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        // Настройка DataGridView
        private void SetupGrid()
        {
            dgvVms.AutoGenerateColumns = false;
            dgvVms.AllowUserToAddRows = false;
            dgvVms.AllowUserToDeleteRows = true;
            dgvVms.ReadOnly = false;

            colId.DataPropertyName = "Id";
            colCpu.DataPropertyName = "Cpu";
            colRam.DataPropertyName = "Ram";
            colDisk.DataPropertyName = "Disk";

            // Конвертация из нередактируемых данных в редактируемые
            _bindableList = _vms.Select(vm => new VmBindable
            {
                Id = vm.Id,
                Cpu = vm.Cpu,
                Ram = vm.Ram,
                Disk = vm.Disk
            }).ToList();

            dgvVms.DataSource = null;
            dgvVms.DataSource = _bindableList;
        }

        // Добалвение новой ВМ с нулевыми параметрами
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int maxId = _bindableList.Any() ? _bindableList.Max(x => x.Id) : 0;
            _bindableList.Add(new VmBindable
            {
                Id = maxId + 1,
                Cpu = 0,
                Ram = 0,
                Disk = 0
            });

            dgvVms.DataSource = null;
            dgvVms.DataSource = _bindableList;

            // Авто-переход к новой строке и включение режима редактирования
            int idx = dgvVms.Rows.Count - 1;
            if (idx >= 0 && idx < dgvVms.Rows.Count)
            {
                dgvVms.FirstDisplayedScrollingRowIndex = idx;
                dgvVms.CurrentCell = dgvVms.Rows[idx].Cells["colCpu"];
                dgvVms.BeginEdit(true);
            }
        }

        // Сохранение/применение изменений
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvVms.EndEdit();

            foreach (DataGridViewRow row in dgvVms.Rows)
            {
                if (row.IsNewRow || row.Cells["colId"].Value == null) continue;

                // Валидация данных
                int id = Convert.ToInt32(row.Cells["colId"].Value);
                if (row.Cells["colCpu"].Value == null || Convert.ToDouble(row.Cells["colCpu"].Value) <= 0)
                {
                    MessageBox.Show($"ВМ #{id}: CPU должен быть > 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            UpdatedVMs = _bindableList
                .Where(b => b != null && b.Id >= 0)
                .Select(b => new VirtualMachine(b.Id, b.Cpu, b.Ram, b.Disk))
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        // Удаление выделенной ВМ
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверка присутствия выделенной строки
            if (dgvVms.SelectedRows.Count == 0)
            {
                MessageBox.Show("ВМ отсутствуют", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получение ID удаляемого ВМ
            var selectedRow = dgvVms.SelectedRows[0];
            if (selectedRow.Cells["colId"].Value == null) return;

            int id = Convert.ToInt32(selectedRow.Cells["colId"].Value);

            // Подтверждение удаления
            var result = MessageBox.Show($"Удалить виртуальную машину #{id}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Удаление из списка и обновление сетки
            _bindableList.RemoveAll(b => b.Id == id);
            dgvVms.DataSource = null;
            dgvVms.DataSource = _bindableList;
        }
    }

    public class VmBindable
    {
        public int Id { get; set; }
        public double Cpu { get; set; }
        public double Ram { get; set; }
        public double Disk { get; set; }
    }
}
