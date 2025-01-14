using System.Diagnostics;
using BOOSE;

namespace ASEproject
{
    /// <summary>
    /// represents the main form
    /// </summary>
    public partial class Form1 : Form
    {
        Parser parser;
        CommandFactory commandFactory;
        ICanvas canvas;
        StoredProgram storedProgram;

        private bool isDarkMode = false;

        private System.Windows.Forms.Label Position; //label fro position display



        /// <summary>
        /// initializes new instances of the <see cref="Form1"/> class
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            Debug.WriteLine(AboutBOOSE.about());
            canvas = new AppCanvas();
            commandFactory = new AppCommandFactory();
            storedProgram = new AppStoredProgram(canvas);
            parser = new AppParser(commandFactory, storedProgram);

            ((AppCanvas)canvas).PenPositionChanged += Canvas_PenPositionChanged; //for pen position when updated

            InitializePositionLabel();
            ProgramWindow2.Focus();
            ConfigureAutoComplete();

            ProgramWindow2.KeyDown += ProgramWindow2_KeyDown;


        }

        /// <summary>
        /// handles the run button click event
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// 
        /// <param name="e">event argument</param>
        private void Run_Click(object sender, EventArgs e)
        {
            try
            {
                //String syntaxErrorList = "";
                //String runtimeErrorList = "";
                String text = ProgramWindow.Text;

                parser.ParseProgram(text);
                storedProgram.Run();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// handles the paint event of the OutputWindow
        /// draws current canvas bitmap onto the OutputWindow
        /// </summary>
        /// <param name="sender">source of the event</param>
        /// <param name="e">event arguments containing paint data</param>
        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)canvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);
        }

        private void DarkMode_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDarkMode(DarkMode.Checked);
        }

        private void ToggleDarkMode(bool enableDarkMode)
        {
            // Define colors for dark mode and light mode
            Color backgroundColor = enableDarkMode ? System.Drawing.Color.Black : System.Drawing.Color.White;
            Color textColor = enableDarkMode ? System.Drawing.Color.White : System.Drawing.Color.Black;

            // Apply colors to the form
            this.BackColor = backgroundColor;
            this.ForeColor = textColor;

            // Apply to the textbox
            ProgramWindow.BackColor = backgroundColor;
            ProgramWindow.ForeColor = textColor;
            ProgramWindow2.BackColor = backgroundColor;
            ProgramWindow2.ForeColor = textColor;

            // Apply to the canvas
            OutputWindow.BackColor = backgroundColor;

            // Update any other controls if necessary
            foreach (Control control in this.Controls)
            {
                if (control is Button || control is CheckBox || control is Label)
                {
                    control.BackColor = backgroundColor;
                    control.ForeColor = textColor;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCanvas();
        }

        private void SaveCanvas()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp",
                    Title = "Save the Canvas"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the canvas bitmap to the selected file
                    Bitmap canvasBitmap = (Bitmap)canvas.getBitmap();
                    canvasBitmap.Save(saveFileDialog.FileName);
                    MessageBox.Show("Canvas saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving canvas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCanvas();
        }

        private void LoadCanvas()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.png;*.jpg;*.bmp",
                    Title = "Load a Canvas Image"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image onto the canvas
                    Bitmap loadedImage = new Bitmap(openFileDialog.FileName);
                    Graphics g = Graphics.FromImage((Bitmap)canvas.getBitmap());
                    g.DrawImage(loadedImage, 0, 0);
                    OutputWindow.Invalidate(); // Refresh the OutputWindow to show the loaded image
                    MessageBox.Show("Canvas loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading canvas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            Refresh();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            canvas.Reset();
            Refresh();
        }

        private void Color_Click(object sender, EventArgs e)
        {
            // You can use a color picker dialog (like ColorDialog) to select a color.
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                canvas.SetColour(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                Refresh();
            }
        }

        private void Canvas_PenPositionChanged(object sender, (int X, int Y) e)
        {
            Console.WriteLine($"Pen Position: ({e.X}, {e.Y})");

            Position.Text = $"Position: ({e.X}, {e.Y})";
            Position.Refresh();
            Position.Visible = true;  // Ensure the label is visible


        }

        private void InitializePositionLabel()
        {
            this.Position = new Label
            {
                Name = "Position",
                Text = "Position: (0, 0)",
                Location = new Point(728, 693), // Adjust position as needed
                AutoSize = true
            };
            this.Controls.Add(Position);
        }

        private void UpdatePenPosition(int x, int y)
        {
            Position.Text = $"Position: ({x}, {y})";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfigureAutoComplete()
        {
            // Create an AutoCompleteStringCollection and add the commands
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

            autoCompleteCollection.Add("MoveTo");
            autoCompleteCollection.Add("DrawTo");
            autoCompleteCollection.Add("Circle");
            autoCompleteCollection.Add("Rect");
            autoCompleteCollection.Add("Clear");
            autoCompleteCollection.Add("Reset");
            autoCompleteCollection.Add("Pen");
            autoCompleteCollection.Add("Tri");
            autoCompleteCollection.Add("Write");
            autoCompleteCollection.Add("Int");
            autoCompleteCollection.Add("Real");
            autoCompleteCollection.Add("Peek");
            autoCompleteCollection.Add("Poke");
            autoCompleteCollection.Add("Array");
            autoCompleteCollection.Add("If");
            autoCompleteCollection.Add("Else");
            autoCompleteCollection.Add("For");
            autoCompleteCollection.Add("While");
            autoCompleteCollection.Add("End");

            ProgramWindow2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ProgramWindow2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ProgramWindow2.AutoCompleteCustomSource = autoCompleteCollection;

            Refresh();

        }

        private void ProgramWindow2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the 'ding' sound on Enter
                try
                {
                    String text = ProgramWindow2.Text;

                    parser.ParseProgram(text);
                    storedProgram.Run();
                    Refresh();
                    ProgramWindow2.Text ="";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing command: {ex.Message}", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
