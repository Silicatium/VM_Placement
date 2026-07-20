namespace OptimizationDiplom
{
    partial class SettingsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblPopSize = new Label();
            nudPopSize = new NumericUpDown();
            lblGenerations = new Label();
            nudGenerations = new NumericUpDown();
            lblSelectionProb = new Label();
            nudSelectionProb = new NumericUpDown();
            lblMutationProb = new Label();
            nudMutationProb = new NumericUpDown();
            lblElitism = new Label();
            nudElitism = new NumericUpDown();
            lblTournament = new Label();
            nudTournament = new NumericUpDown();
            lblMaxMig = new Label();
            nudMaxMig = new NumericUpDown();
            lblLoadLimit = new Label();
            nudLoadLimit = new NumericUpDown();
            lblCapPen = new Label();
            nudCapPen = new NumericUpDown();
            lblMigPen = new Label();
            nudMigPen = new NumericUpDown();
            lblSeed = new Label();
            nudSeed = new NumericUpDown();
            lblProgressInt = new Label();
            nudProgressInt = new NumericUpDown();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPopSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGenerations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSelectionProb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMutationProb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudElitism).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTournament).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxMig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLoadLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapPen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMigPen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudProgressInt).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.Controls.Add(lblPopSize, 0, 0);
            tableLayoutPanel1.Controls.Add(nudPopSize, 1, 0);
            tableLayoutPanel1.Controls.Add(lblGenerations, 0, 1);
            tableLayoutPanel1.Controls.Add(nudGenerations, 1, 1);
            tableLayoutPanel1.Controls.Add(lblSelectionProb, 0, 2);
            tableLayoutPanel1.Controls.Add(nudSelectionProb, 1, 2);
            tableLayoutPanel1.Controls.Add(lblMutationProb, 0, 3);
            tableLayoutPanel1.Controls.Add(nudMutationProb, 1, 3);
            tableLayoutPanel1.Controls.Add(lblElitism, 0, 4);
            tableLayoutPanel1.Controls.Add(nudElitism, 1, 4);
            tableLayoutPanel1.Controls.Add(lblTournament, 0, 5);
            tableLayoutPanel1.Controls.Add(nudTournament, 1, 5);
            tableLayoutPanel1.Controls.Add(lblMaxMig, 0, 6);
            tableLayoutPanel1.Controls.Add(nudMaxMig, 1, 6);
            tableLayoutPanel1.Controls.Add(lblLoadLimit, 0, 7);
            tableLayoutPanel1.Controls.Add(nudLoadLimit, 1, 7);
            tableLayoutPanel1.Controls.Add(lblCapPen, 0, 8);
            tableLayoutPanel1.Controls.Add(nudCapPen, 1, 8);
            tableLayoutPanel1.Controls.Add(lblMigPen, 0, 9);
            tableLayoutPanel1.Controls.Add(nudMigPen, 1, 9);
            tableLayoutPanel1.Controls.Add(lblSeed, 0, 10);
            tableLayoutPanel1.Controls.Add(nudSeed, 1, 10);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 13;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(480, 373);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblPopSize
            // 
            lblPopSize.Dock = DockStyle.Fill;
            lblPopSize.Location = new Point(3, 0);
            lblPopSize.Name = "lblPopSize";
            lblPopSize.Size = new Size(258, 34);
            lblPopSize.TabIndex = 0;
            lblPopSize.Text = "Размер популяции:";
            lblPopSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudPopSize
            // 
            nudPopSize.Dock = DockStyle.Fill;
            nudPopSize.Location = new Point(267, 3);
            nudPopSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPopSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudPopSize.Name = "nudPopSize";
            nudPopSize.Size = new Size(210, 23);
            nudPopSize.TabIndex = 1;
            nudPopSize.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // lblGenerations
            // 
            lblGenerations.Dock = DockStyle.Fill;
            lblGenerations.Location = new Point(3, 34);
            lblGenerations.Name = "lblGenerations";
            lblGenerations.Size = new Size(258, 34);
            lblGenerations.TabIndex = 2;
            lblGenerations.Text = "Количество поколений:";
            lblGenerations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudGenerations
            // 
            nudGenerations.Dock = DockStyle.Fill;
            nudGenerations.Location = new Point(267, 37);
            nudGenerations.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudGenerations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGenerations.Name = "nudGenerations";
            nudGenerations.Size = new Size(210, 23);
            nudGenerations.TabIndex = 3;
            nudGenerations.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblSelectionProb
            // 
            lblSelectionProb.Dock = DockStyle.Fill;
            lblSelectionProb.Location = new Point(3, 68);
            lblSelectionProb.Name = "lblSelectionProb";
            lblSelectionProb.Size = new Size(258, 34);
            lblSelectionProb.TabIndex = 4;
            lblSelectionProb.Text = "Вероятность скрещивания (0-1):";
            lblSelectionProb.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudSelectionProb
            // 
            nudSelectionProb.DecimalPlaces = 2;
            nudSelectionProb.Dock = DockStyle.Fill;
            nudSelectionProb.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudSelectionProb.Location = new Point(267, 71);
            nudSelectionProb.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSelectionProb.Name = "nudSelectionProb";
            nudSelectionProb.Size = new Size(210, 23);
            nudSelectionProb.TabIndex = 5;
            nudSelectionProb.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            // 
            // lblMutationProb
            // 
            lblMutationProb.Dock = DockStyle.Fill;
            lblMutationProb.Location = new Point(3, 102);
            lblMutationProb.Name = "lblMutationProb";
            lblMutationProb.Size = new Size(258, 34);
            lblMutationProb.TabIndex = 6;
            lblMutationProb.Text = "Вероятность мутации (0-1):";
            lblMutationProb.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudMutationProb
            // 
            nudMutationProb.DecimalPlaces = 2;
            nudMutationProb.Dock = DockStyle.Fill;
            nudMutationProb.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudMutationProb.Location = new Point(267, 105);
            nudMutationProb.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMutationProb.Name = "nudMutationProb";
            nudMutationProb.Size = new Size(210, 23);
            nudMutationProb.TabIndex = 7;
            nudMutationProb.Value = new decimal(new int[] { 15, 0, 0, 131072 });
            // 
            // lblElitism
            // 
            lblElitism.Dock = DockStyle.Fill;
            lblElitism.Location = new Point(3, 136);
            lblElitism.Name = "lblElitism";
            lblElitism.Size = new Size(258, 34);
            lblElitism.TabIndex = 8;
            lblElitism.Text = "Количество лучших для сохранения:";
            lblElitism.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudElitism
            // 
            nudElitism.Dock = DockStyle.Fill;
            nudElitism.Location = new Point(267, 139);
            nudElitism.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudElitism.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudElitism.Name = "nudElitism";
            nudElitism.Size = new Size(210, 23);
            nudElitism.TabIndex = 9;
            nudElitism.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblTournament
            // 
            lblTournament.Dock = DockStyle.Fill;
            lblTournament.Location = new Point(3, 170);
            lblTournament.Name = "lblTournament";
            lblTournament.Size = new Size(258, 34);
            lblTournament.TabIndex = 10;
            lblTournament.Text = "Кандидатов на выбор родителя:";
            lblTournament.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudTournament
            // 
            nudTournament.Dock = DockStyle.Fill;
            nudTournament.Location = new Point(267, 173);
            nudTournament.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudTournament.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudTournament.Name = "nudTournament";
            nudTournament.Size = new Size(210, 23);
            nudTournament.TabIndex = 11;
            nudTournament.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblMaxMig
            // 
            lblMaxMig.Dock = DockStyle.Fill;
            lblMaxMig.Location = new Point(3, 204);
            lblMaxMig.Name = "lblMaxMig";
            lblMaxMig.Size = new Size(258, 34);
            lblMaxMig.TabIndex = 12;
            lblMaxMig.Text = "Максимум миграций:";
            lblMaxMig.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudMaxMig
            // 
            nudMaxMig.Dock = DockStyle.Fill;
            nudMaxMig.Location = new Point(267, 207);
            nudMaxMig.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudMaxMig.Name = "nudMaxMig";
            nudMaxMig.Size = new Size(210, 23);
            nudMaxMig.TabIndex = 13;
            nudMaxMig.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblLoadLimit
            // 
            lblLoadLimit.Dock = DockStyle.Fill;
            lblLoadLimit.Location = new Point(3, 238);
            lblLoadLimit.Name = "lblLoadLimit";
            lblLoadLimit.Size = new Size(258, 34);
            lblLoadLimit.TabIndex = 14;
            lblLoadLimit.Text = "Лимит загрузки сервера (0-1):";
            lblLoadLimit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudLoadLimit
            // 
            nudLoadLimit.DecimalPlaces = 2;
            nudLoadLimit.Dock = DockStyle.Fill;
            nudLoadLimit.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudLoadLimit.Location = new Point(267, 241);
            nudLoadLimit.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLoadLimit.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudLoadLimit.Name = "nudLoadLimit";
            nudLoadLimit.Size = new Size(210, 23);
            nudLoadLimit.TabIndex = 15;
            nudLoadLimit.Value = new decimal(new int[] { 85, 0, 0, 131072 });
            // 
            // lblCapPen
            // 
            lblCapPen.Dock = DockStyle.Fill;
            lblCapPen.Location = new Point(3, 272);
            lblCapPen.Name = "lblCapPen";
            lblCapPen.Size = new Size(258, 34);
            lblCapPen.TabIndex = 16;
            lblCapPen.Text = "Штраф за перегрузку:";
            lblCapPen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudCapPen
            // 
            nudCapPen.Dock = DockStyle.Fill;
            nudCapPen.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudCapPen.Location = new Point(267, 275);
            nudCapPen.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCapPen.Name = "nudCapPen";
            nudCapPen.Size = new Size(210, 23);
            nudCapPen.TabIndex = 17;
            nudCapPen.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // lblMigPen
            // 
            lblMigPen.Dock = DockStyle.Fill;
            lblMigPen.Location = new Point(3, 306);
            lblMigPen.Name = "lblMigPen";
            lblMigPen.Size = new Size(258, 34);
            lblMigPen.TabIndex = 18;
            lblMigPen.Text = "Штраф за миграции:";
            lblMigPen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudMigPen
            // 
            nudMigPen.Dock = DockStyle.Fill;
            nudMigPen.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudMigPen.Location = new Point(267, 309);
            nudMigPen.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudMigPen.Name = "nudMigPen";
            nudMigPen.Size = new Size(210, 23);
            nudMigPen.TabIndex = 19;
            nudMigPen.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // lblSeed
            // 
            lblSeed.Dock = DockStyle.Fill;
            lblSeed.Location = new Point(3, 340);
            lblSeed.Name = "lblSeed";
            lblSeed.Size = new Size(258, 34);
            lblSeed.TabIndex = 20;
            lblSeed.Text = "Random Seed (0 = случайный):";
            lblSeed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudSeed
            // 
            nudSeed.Dock = DockStyle.Fill;
            nudSeed.Location = new Point(267, 343);
            nudSeed.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudSeed.Name = "nudSeed";
            nudSeed.Size = new Size(210, 23);
            nudSeed.TabIndex = 21;
            // 
            // lblProgressInt
            // 
            lblProgressInt.Location = new Point(0, 0);
            lblProgressInt.Name = "lblProgressInt";
            lblProgressInt.Size = new Size(100, 23);
            lblProgressInt.TabIndex = 0;
            // 
            // nudProgressInt
            // 
            nudProgressInt.Location = new Point(0, 0);
            nudProgressInt.Name = "nudProgressInt";
            nudProgressInt.Size = new Size(120, 23);
            nudProgressInt.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 373);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(480, 50);
            panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(370, 10);
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
            btnSave.Location = new Point(270, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 423);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки генетического алгоритма";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudPopSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGenerations).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSelectionProb).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMutationProb).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudElitism).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTournament).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxMig).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLoadLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapPen).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMigPen).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudProgressInt).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
        private Label lblPopSize;
        private Label lblGenerations;
        private Label lblSelectionProb;
        private Label lblMutationProb;
        private Label lblElitism;
        private Label lblTournament;
        private Label lblMaxMig;
        private Label lblLoadLimit;
        private Label lblCapPen;
        private Label lblMigPen;
        private Label lblProgressInt;
        private Label lblSeed;
        private NumericUpDown nudPopSize;
        private NumericUpDown nudGenerations;
        private NumericUpDown nudSelectionProb;
        private NumericUpDown nudMutationProb;
        private NumericUpDown nudElitism;
        private NumericUpDown nudTournament;
        private NumericUpDown nudMaxMig;
        private NumericUpDown nudLoadLimit;
        private NumericUpDown nudCapPen;
        private NumericUpDown nudMigPen;
        private NumericUpDown nudProgressInt;
        private NumericUpDown nudSeed;
    }
}
