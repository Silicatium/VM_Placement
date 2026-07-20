namespace OptimizationDiplom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            vmEditorToolStripMenuItem = new ToolStripMenuItem();
            serverEditorToolStripMenuItem = new ToolStripMenuItem();
            btnOptimize = new Button();
            splitContainer1 = new SplitContainer();
            panelLeft = new Panel();
            panelB = new Panel();
            panelStatsOld = new Panel();
            lblStatsOld = new Label();
            lblLeftTitle = new Label();
            panelRight = new Panel();
            panelBNew = new Panel();
            panelStats = new Panel();
            lblStats = new Label();
            lblRightTitle = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft.SuspendLayout();
            panelStatsOld.SuspendLayout();
            panelRight.SuspendLayout();
            panelStats.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 2, 0, 2);
            menuStrip1.Size = new Size(1584, 24);
            menuStrip1.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(133, 22);
            loadToolStripMenuItem.Text = "Загрузить";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(133, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, vmEditorToolStripMenuItem, serverEditorToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(95, 20);
            toolsToolStripMenuItem.Text = "Инструменты";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(178, 22);
            settingsToolStripMenuItem.Text = "Настройки ГА";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // vmEditorToolStripMenuItem
            // 
            vmEditorToolStripMenuItem.Name = "vmEditorToolStripMenuItem";
            vmEditorToolStripMenuItem.Size = new Size(178, 22);
            vmEditorToolStripMenuItem.Text = "Редактор ВМ";
            vmEditorToolStripMenuItem.Click += vmEditorToolStripMenuItem_Click;
            // 
            // serverEditorToolStripMenuItem
            // 
            serverEditorToolStripMenuItem.Name = "serverEditorToolStripMenuItem";
            serverEditorToolStripMenuItem.Size = new Size(178, 22);
            serverEditorToolStripMenuItem.Text = "Редактор серверов";
            serverEditorToolStripMenuItem.Click += serverEditorToolStripMenuItem_Click;
            // 
            // btnOptimize
            // 
            btnOptimize.BackColor = Color.FromArgb(37, 99, 235);
            btnOptimize.Dock = DockStyle.Right;
            btnOptimize.FlatStyle = FlatStyle.Flat;
            btnOptimize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOptimize.ForeColor = Color.White;
            btnOptimize.Location = new Point(585, 0);
            btnOptimize.Name = "btnOptimize";
            btnOptimize.Size = new Size(200, 58);
            btnOptimize.TabIndex = 0;
            btnOptimize.Text = "Произвести перераспределение";
            btnOptimize.UseVisualStyleBackColor = false;
            btnOptimize.Click += btnOptimize_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeft);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelRight);
            splitContainer1.Size = new Size(1584, 837);
            splitContainer1.SplitterDistance = 813;
            splitContainer1.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(245, 247, 250);
            panelLeft.Controls.Add(panelB);
            panelLeft.Controls.Add(panelStatsOld);
            panelLeft.Controls.Add(lblLeftTitle);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(12);
            panelLeft.Size = new Size(811, 835);
            panelLeft.TabIndex = 0;
            // 
            // panelB
            // 
            panelB.AutoScroll = true;
            panelB.BackColor = Color.Transparent;
            panelB.Dock = DockStyle.Fill;
            panelB.Location = new Point(12, 40);
            panelB.Name = "panelB";
            panelB.Size = new Size(787, 723);
            panelB.TabIndex = 0;
            // 
            // panelStatsOld
            // 
            panelStatsOld.AutoSize = true;
            panelStatsOld.BackColor = Color.White;
            panelStatsOld.BorderStyle = BorderStyle.FixedSingle;
            panelStatsOld.Controls.Add(lblStatsOld);
            panelStatsOld.Controls.Add(btnOptimize);
            panelStatsOld.Dock = DockStyle.Bottom;
            panelStatsOld.Location = new Point(12, 763);
            panelStatsOld.MinimumSize = new Size(200, 0);
            panelStatsOld.Name = "panelStatsOld";
            panelStatsOld.Size = new Size(787, 60);
            panelStatsOld.TabIndex = 1;
            // 
            // lblStatsOld
            // 
            lblStatsOld.Dock = DockStyle.Bottom;
            lblStatsOld.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatsOld.ForeColor = Color.FromArgb(16, 185, 129);
            lblStatsOld.Location = new Point(0, 0);
            lblStatsOld.Name = "lblStatsOld";
            lblStatsOld.Size = new Size(585, 58);
            lblStatsOld.TabIndex = 0;
            lblStatsOld.Text = "Энергия:";
            lblStatsOld.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.Dock = DockStyle.Top;
            lblLeftTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeftTitle.Location = new Point(12, 12);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(787, 28);
            lblLeftTitle.TabIndex = 1;
            lblLeftTitle.Text = "Текущее распределение";
            lblLeftTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(245, 247, 250);
            panelRight.Controls.Add(panelBNew);
            panelRight.Controls.Add(panelStats);
            panelRight.Controls.Add(lblRightTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(12);
            panelRight.Size = new Size(765, 835);
            panelRight.TabIndex = 0;
            // 
            // panelBNew
            // 
            panelBNew.AutoScroll = true;
            panelBNew.BackColor = Color.Transparent;
            panelBNew.Dock = DockStyle.Fill;
            panelBNew.Location = new Point(12, 40);
            panelBNew.Name = "panelBNew";
            panelBNew.Size = new Size(741, 723);
            panelBNew.TabIndex = 1;
            // 
            // panelStats
            // 
            panelStats.BackColor = Color.White;
            panelStats.BorderStyle = BorderStyle.FixedSingle;
            panelStats.Controls.Add(lblStats);
            panelStats.Dock = DockStyle.Bottom;
            panelStats.Location = new Point(12, 763);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(741, 60);
            panelStats.TabIndex = 0;
            // 
            // lblStats
            // 
            lblStats.Dock = DockStyle.Fill;
            lblStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStats.ForeColor = Color.FromArgb(30, 41, 59);
            lblStats.Location = new Point(0, 0);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(739, 58);
            lblStats.TabIndex = 0;
            lblStats.Text = "Нажмите \"Уплотнение распреденеия\"";
            lblStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRightTitle
            // 
            lblRightTitle.Dock = DockStyle.Top;
            lblRightTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRightTitle.Location = new Point(12, 12);
            lblRightTitle.Name = "lblRightTitle";
            lblRightTitle.Size = new Size(741, 28);
            lblRightTitle.TabIndex = 2;
            lblRightTitle.Text = "Новое распределение";
            lblRightTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VM Consolidation Optimizer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelStatsOld.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelStats.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem vmEditorToolStripMenuItem;
        private ToolStripMenuItem serverEditorToolStripMenuItem;
        private Button btnOptimize;
        private SplitContainer splitContainer1;
        private Panel panelLeft;
        private Label lblLeftTitle;
        private Panel panelB;
        private Panel panelRight;
        private Label lblRightTitle;
        private Panel panelBNew;
        private Panel panelStats;
        private Label lblStats;
        private Panel panelStatsOld;
        private Label lblStatsOld;
    }
}