using BOOSE;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class Write : CommandOneParameter
    {
        private string text=" ";

        public Write()
        {
        }

        public Write(Canvas c,string text)
            : base(c)
        {
            this.text = text;
        }

        public override void Execute()
        {
            //base.Execute();
            text = base.Parameters[0];

            base.Canvas.WriteText(base.Parameters[0]);
        }

        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length < 0)
            {
                throw new CommandException("There must be atleast one parameter");
            }
        }
    }
}
