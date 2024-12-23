using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Reset : CommandOneParameter
{

    private string[] parameters;

    public Reset()
    {
    }
    public Reset(Canvas canvas) : base(canvas)
    {

    }


    public override void Execute()
    {

        canvas.Reset();
        string message = "Canvas reset successfully";
        MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    public void CheckParameters(string[] Parameters)
    {

        if (Parameters.Length > 0)
            throw new ArgumentException("Reset command does not require any parameters.");
    }
}