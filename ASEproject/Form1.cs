using System.Diagnostics;
using BOOSE;

namespace ASEproject
{
    public partial class Form1 : Form
    {
        Parser parser;
        CommandFactory commandFactory;
        ICanvas canvas;
        StoredProgram storedProgram;

        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            canvas = new AppCanvas();
            commandFactory = new AppCommandFactory();
            storedProgram = new StoredProgram(canvas);
            parser = new Parser(commandFactory, storedProgram);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            String syntaxErrorList = "";
            String runtimeErrorList = "";
            String text = ProgramWindow.Text;

            parser.ParseProgram(text);
            storedProgram.Run();
            Refresh();
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g =e.Graphics;
            Bitmap b = (Bitmap) canvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);
        }
    }
}
