using BOOSE;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppStoredProgram : StoredProgram
    {
        private Stack stack = new Stack();

        public AppStoredProgram(ICanvas canvas) : base(canvas) { }

        public override void Push(ConditionalCommand Com)
        {
            stack.Push(Com);
        }

        public override ConditionalCommand Pop()
        {
            try
            {
                return (ConditionalCommand) stack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new StoredProgramException("Missing while/if/for/method");
            }
        }

        public override void Run()
        {
            int num = 0;

            while (base.Commandsleft())
            {
                ICommand command = (ICommand)base.NextCommand();
                try
                {
                    num++;
                    command.Execute();
                }
                catch (BOOSEException ex)
                {
                    base.SyntaxOk = false;
                    throw new StoredProgramException($"{ex.Message} {PC}");
                }

                if (num > 50000 && PC < 20)
                {
                    throw new StoredProgramException("Infinite loop");
                }
            }
            if (stack.Count != 0)
            {
                Pop();
                base.SyntaxOk = false;
                throw new StoredProgramException("Missing end");
            }
        }
    }
}
