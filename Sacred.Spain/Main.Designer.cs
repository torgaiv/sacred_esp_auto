namespace Sacred.Spain
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            splitContainer = new SplitContainer();
            menuStrip1 = new MenuStrip();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            layoutBackground = new TableLayoutPanel();
            tbFolderPath = new TextBox();
            btSearchPath = new Button();
            lbSacredFolder = new Label();
            btPatch = new Button();
            tbLogs = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            menuStrip1.SuspendLayout();
            layoutBackground.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.IsSplitterFixed = true;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(layoutBackground);
            splitContainer.Size = new Size(784, 261);
            splitContainer.SplitterDistance = 25;
            splitContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            ayudaToolStripMenuItem.Click += ayudaToolStripMenuItem_Click;
            // 
            // layoutBackground
            // 
            layoutBackground.ColumnCount = 6;
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            layoutBackground.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            layoutBackground.Controls.Add(tbFolderPath, 2, 1);
            layoutBackground.Controls.Add(btSearchPath, 4, 1);
            layoutBackground.Controls.Add(lbSacredFolder, 1, 1);
            layoutBackground.Controls.Add(btPatch, 4, 2);
            layoutBackground.Controls.Add(tbLogs, 1, 3);
            layoutBackground.Dock = DockStyle.Fill;
            layoutBackground.Location = new Point(0, 0);
            layoutBackground.Name = "layoutBackground";
            layoutBackground.RowCount = 6;
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layoutBackground.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            layoutBackground.Size = new Size(784, 232);
            layoutBackground.TabIndex = 1;
            // 
            // tbFolderPath
            // 
            tbFolderPath.Anchor = AnchorStyles.Left;
            layoutBackground.SetColumnSpan(tbFolderPath, 2);
            tbFolderPath.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbFolderPath.Location = new Point(143, 36);
            tbFolderPath.Name = "tbFolderPath";
            tbFolderPath.ScrollBars = ScrollBars.Horizontal;
            tbFolderPath.Size = new Size(542, 20);
            tbFolderPath.TabIndex = 1;
            tbFolderPath.Text = "Z:\\Program Files (x86)\\Steam\\steamapps\\common\\Sacred Gold";
            // 
            // btSearchPath
            // 
            btSearchPath.Anchor = AnchorStyles.Left;
            btSearchPath.Location = new Point(691, 34);
            btSearchPath.MaximumSize = new Size(125, 23);
            btSearchPath.Name = "btSearchPath";
            btSearchPath.Size = new Size(72, 23);
            btSearchPath.TabIndex = 0;
            btSearchPath.Text = "Explorar";
            btSearchPath.UseVisualStyleBackColor = true;
            btSearchPath.Click += btSearchPath_Click;
            // 
            // lbSacredFolder
            // 
            lbSacredFolder.AutoSize = true;
            lbSacredFolder.Dock = DockStyle.Fill;
            lbSacredFolder.Location = new Point(18, 23);
            lbSacredFolder.Name = "lbSacredFolder";
            lbSacredFolder.Size = new Size(119, 46);
            lbSacredFolder.TabIndex = 2;
            lbSacredFolder.Text = "Carpeta de instalación Sacred:";
            lbSacredFolder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btPatch
            // 
            btPatch.Dock = DockStyle.Fill;
            btPatch.Location = new Point(691, 72);
            btPatch.MaximumSize = new Size(125, 23);
            btPatch.Name = "btPatch";
            btPatch.Size = new Size(72, 23);
            btPatch.TabIndex = 3;
            btPatch.Text = "Aplicar parche";
            btPatch.UseVisualStyleBackColor = true;
            btPatch.Click += btPatch_Click;
            // 
            // tbLogs
            // 
            layoutBackground.SetColumnSpan(tbLogs, 4);
            tbLogs.Dock = DockStyle.Fill;
            tbLogs.Location = new Point(18, 118);
            tbLogs.Name = "tbLogs";
            layoutBackground.SetRowSpan(tbLogs, 2);
            tbLogs.Size = new Size(745, 98);
            tbLogs.TabIndex = 4;
            tbLogs.Text = "";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 261);
            Controls.Add(splitContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(800, 300);
            MinimumSize = new Size(800, 300);
            Name = "Main";
            Text = "Sacred Español";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            layoutBackground.ResumeLayout(false);
            layoutBackground.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private TableLayoutPanel layoutBackground;
        private TextBox tbFolderPath;
        private Button btSearchPath;
        private Label lbSacredFolder;
        private Button btPatch;
        private RichTextBox tbLogs;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ayudaToolStripMenuItem;
    }
}
