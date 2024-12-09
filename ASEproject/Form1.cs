using System.Diagnostics;
using BOOSE;

namespace ASEproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
        }
    }
}
