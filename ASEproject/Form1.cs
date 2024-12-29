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

        /// <summary>
        /// initializes new instances of the <see cref"Form1"/> class
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            canvas = new AppCanvas();
            commandFactory = new AppCommandFactory();
            storedProgram = new StoredProgram(canvas);
            parser = new Parser(commandFactory, storedProgram);
        }

        /// <summary>
        /// handles the run button click event
        /// </summary>
        /// <param name="sender">source of the event</param>
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
            Graphics g =e.Graphics;
            Bitmap b = (Bitmap) canvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);
        }
    }
}
