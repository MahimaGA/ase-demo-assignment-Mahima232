namespace ASEproject
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
            Run = new Button();
            ProgramWindow = new TextBox();
            OutputWindow = new PictureBox();
            DarkMode = new CheckBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            Reset = new Button();
            Clear = new Button();
            ((System.ComponentModel.ISupportInitialize)OutputWindow).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Run
            // 
            Run.Location = new Point(49, 92);
            Run.Name = "Run";
            Run.Size = new Size(188, 58);
            Run.TabIndex = 0;
            Run.Text = "Run";
            Run.UseVisualStyleBackColor = true;
            Run.Click += Run_Click;
            // 
            // ProgramWindow
            // 
            ProgramWindow.Location = new Point(50, 180);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(629, 481);
            ProgramWindow.TabIndex = 1;
            // 
            // OutputWindow
            // 
            OutputWindow.BackColor = SystemColors.ControlDark;
            OutputWindow.Location = new Point(728, 180);
            OutputWindow.Name = "OutputWindow";
            OutputWindow.Size = new Size(629, 481);
            OutputWindow.TabIndex = 2;
            OutputWindow.TabStop = false;
            OutputWindow.Paint += OutputWindow_Paint;
            // 
            // DarkMode
            // 
            DarkMode.AutoSize = true;
            DarkMode.Location = new Point(1153, 693);
            DarkMode.Name = "DarkMode";
            DarkMode.Size = new Size(204, 45);
            DarkMode.TabIndex = 3;
            DarkMode.Text = "Dark Mode";
            DarkMode.UseVisualStyleBackColor = true;
            DarkMode.CheckedChanged += DarkMode_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1461, 49);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(87, 45);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(249, 54);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(249, 54);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // Reset
            // 
            Reset.Location = new Point(975, 92);
            Reset.Name = "Reset";
            Reset.Size = new Size(188, 58);
            Reset.TabIndex = 5;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += Reset_Click;
            // 
            // Clear
            // 
            Clear.Location = new Point(1169, 92);
            Clear.Name = "Clear";
            Clear.Size = new Size(188, 58);
            Clear.TabIndex = 6;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 789);
            Controls.Add(Clear);
            Controls.Add(Reset);
            Controls.Add(DarkMode);
            Controls.Add(OutputWindow);
            Controls.Add(ProgramWindow);
            Controls.Add(Run);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)OutputWindow).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Run;
        private TextBox ProgramWindow;
        private PictureBox OutputWindow;
        private CheckBox DarkMode;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private Button Reset;
        private Button Clear;
    }
}
