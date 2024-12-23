using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

public class Clear : CommandOneParameter
    {

        private string[] parameters;

        public Clear()
        {
        }
        public Clear(Canvas canvas) : base(canvas)
        {

        }


        public override void Execute()
        {

            canvas.Clear();
            string message = "Canvas Clear successfully";
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void CheckParameters(string[] Parameters)
        {

            if (Parameters.Length > 0)
                throw new ArgumentException("Clear command does not require any parameters.");
        }
    }
