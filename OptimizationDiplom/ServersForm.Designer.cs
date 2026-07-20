namespace OptimizationDiplom
{
    partial class ServersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvServers = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCpuCap = new DataGridViewTextBoxColumn();
            colRamCap = new DataGridViewTextBoxColumn();
            colDiskCap = new DataGridViewTextBoxColumn();
            colEIdle = new DataGridViewTextBoxColumn();
            colEMax = new DataGridViewTextBoxColumn();
            panelBottom = new Panel();
            btnAdd = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvServers).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvServers
            // 
            dgvServers.AllowUserToAddRows = false;
            dgvServers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServers.Columns.AddRange(new DataGridViewColumn[] { colId, colCpuCap, colRamCap, colDiskCap, colEIdle, colEMax });
            dgvServers.Dock = DockStyle.Fill;
            dgvServers.Location = new Point(0, 0);
            dgvServers.Name = "dgvServers";
            dgvServers.RowHeadersVisible = false;
            dgvServers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServers.Size = new Size(850, 500);
            dgvServers.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colCpuCap
            // 
            colCpuCap.HeaderText = "CPU Cap";
            colCpuCap.Name = "colCpuCap";
            // 
            // colRamCap
            // 
            colRamCap.HeaderText = "RAM Cap";
            colRamCap.Name = "colRamCap";
            // 
            // colDiskCap
            // 
            colDiskCap.HeaderText = "Disk Cap";
            colDiskCap.Name = "colDiskCap";
            // 
            // colEIdle
            // 
            colEIdle.HeaderText = "E_idle";
            colEIdle.Name = "colEIdle";
            // 
            // colEMax
            // 
            colEMax.HeaderText = "E_max";
            colEMax.Name = "colEMax";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(btnAdd);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 500);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10);
            panelBottom.Size = new Size(850, 50);
            panelBottom.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(13, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить сервер";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(747, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(640, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(159, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseMnemonic = false;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ServersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 550);
            Controls.Add(dgvServers);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактор физических серверов";
            ((System.ComponentModel.ISupportInitialize)dgvServers).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvServers;
        private Panel panelBottom;
        private Button btnAdd;
        private Button btnSave;
        private Button btnCancel;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCpuCap;
        private DataGridViewTextBoxColumn colRamCap;
        private DataGridViewTextBoxColumn colDiskCap;
        private DataGridViewTextBoxColumn colEIdle;
        private DataGridViewTextBoxColumn colEMax;
        private Button btnDelete;
    }
}