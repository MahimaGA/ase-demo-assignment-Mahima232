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
            ((System.ComponentModel.ISupportInitialize)OutputWindow).BeginInit();
            SuspendLayout();
            // 
            // Run
            // 
            Run.Location = new Point(43, 36);
            Run.Name = "Run";
            Run.Size = new Size(188, 58);
            Run.TabIndex = 0;
            Run.Text = "Run";
            Run.UseVisualStyleBackColor = true;
            Run.Click += Run_Click;
            // 
            // ProgramWindow
            // 
            ProgramWindow.Location = new Point(44, 124);
            ProgramWindow.Multiline = true;
            ProgramWindow.Name = "ProgramWindow";
            ProgramWindow.Size = new Size(629, 481);
            ProgramWindow.TabIndex = 1;
            // 
            // OutputWindow
            // 
            OutputWindow.BackColor = SystemColors.ControlDark;
            OutputWindow.Location = new Point(722, 124);
            OutputWindow.Name = "OutputWindow";
            OutputWindow.Size = new Size(629, 481);
            OutputWindow.TabIndex = 2;
            OutputWindow.TabStop = false;
            OutputWindow.Paint += OutputWindow_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1456, 697);
            Controls.Add(OutputWindow);
            Controls.Add(ProgramWindow);
            Controls.Add(Run);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)OutputWindow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Run;
        private TextBox ProgramWindow;
        private PictureBox OutputWindow;
    }
}
