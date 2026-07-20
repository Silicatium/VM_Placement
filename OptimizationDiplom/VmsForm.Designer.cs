namespace OptimizationDiplom
{
    partial class VmsForm
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
            dgvVms = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCpu = new DataGridViewTextBoxColumn();
            colRam = new DataGridViewTextBoxColumn();
            colDisk = new DataGridViewTextBoxColumn();
            panelBottom = new Panel();
            btnDelete = new Button();
            btnAdd = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVms).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVms
            // 
            dgvVms.AllowUserToAddRows = false;
            dgvVms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVms.Columns.AddRange(new DataGridViewColumn[] { colId, colCpu, colRam, colDisk });
            dgvVms.Dock = DockStyle.Fill;
            dgvVms.Location = new Point(0, 0);
            dgvVms.Name = "dgvVms";
            dgvVms.RowHeadersVisible = false;
            dgvVms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVms.Size = new Size(650, 450);
            dgvVms.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colCpu
            // 
            colCpu.HeaderText = "CPU";
            colCpu.Name = "colCpu";
            // 
            // colRam
            // 
            colRam.HeaderText = "RAM";
            colRam.Name = "colRam";
            // 
            // colDisk
            // 
            colDisk.HeaderText = "Disk";
            colDisk.Name = "colDisk";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnDelete);
            panelBottom.Controls.Add(btnAdd);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 450);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10);
            panelBottom.Size = new Size(650, 50);
            panelBottom.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(139, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            btnAdd.Size = new Size(110, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить ВМ";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(547, 10);
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
            btnSave.Location = new Point(442, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // VmsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 500);
            Controls.Add(dgvVms);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VmsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактор виртуальных машин";
            ((System.ComponentModel.ISupportInitialize)dgvVms).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvVms;
        private Panel panelBottom;
        private Button btnAdd;
        private Button btnSave;
        private Button btnCancel;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCpu;
        private DataGridViewTextBoxColumn colRam;
        private DataGridViewTextBoxColumn colDisk;
        private Button btnDelete;
    }
}