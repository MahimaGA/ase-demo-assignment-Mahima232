using BOOSE;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents a stored program with conditional command stack functionality.
    /// Inherits from the <see cref="StoredProgram"/> class and provides custom implementations for managing commands.
    /// </summary>
    public class AppStoredProgram : StoredProgram
    {
        private Stack stack = new Stack();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppStoredProgram"/> class.
        /// </summary>
        /// <param name="canvas">The canvas to be used by the stored program.</param>
        public AppStoredProgram(ICanvas canvas) : base(canvas) { }

        /// <summary>
        /// Pushes a conditional command onto the stack.
        /// </summary>
        /// <param name="Com">The conditional command to push onto the stack.</param>
        public override void Push(ConditionalCommand Com)
        {
            stack.Push(Com);
        }

        /// <summary>
        /// Pops a conditional command from the stack.
        /// </summary>
        /// <returns>The conditional command popped from the stack.</returns>
        /// <exception cref="StoredProgramException">Thrown if there is an attempt to pop from an empty stack.</exception>
        public override ConditionalCommand Pop()
        {
            try
            {
                return (ConditionalCommand)stack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new StoredProgramException("Missing while/if/for/method");
            }
        }

        /// <summary>
        /// Runs the stored program and executes commands sequentially.
        /// </summary>
        /// <exception cref="StoredProgramException">Thrown if an infinite loop is detected or there is a missing "end" command.</exception>
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
