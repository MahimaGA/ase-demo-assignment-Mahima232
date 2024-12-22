using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class Tri : CommandTwoParameters
    {
        private int width, height;

        public Tri()
        {
        }

        public Tri(Canvas c, int width, int height)
            : base(c)
        {
            this.width = width;
            this.height = height;
        }

        public override void Execute()
        {
            base.Execute();
            width = base.Paramsint[0];
            height = base.Paramsint[1];

            base.Canvas.Tri(base.Paramsint[0], base.Paramsint[1]);
        }

        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 2)
            {
                throw new CommandException("There must be 2 parameters");
            }
        }
    }
}
