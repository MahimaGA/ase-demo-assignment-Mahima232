using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents a parser for the application.
    /// Inherits from the <see cref="Parser"/> class and implements the <see cref="IParser"/> interface.
    /// </summary>
    public class AppParser : Parser, IParser
    {
        private CommandFactory Factory;
        private StoredProgram Program;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppParser"/> class.
        /// </summary>
        /// <param name="Factory">The command factory used to create commands.</param>
        /// <param name="Program">The stored program being parsed.</param>
        public AppParser(CommandFactory Factory, StoredProgram Program) : base(Factory, Program)
        {
            this.Factory = Factory;
            this.Program = Program;
        }

        /// <summary>
        /// Parses the given program and processes each command.
        /// </summary>
        /// <param name="program">The program code to be parsed.</param>
        /// <exception cref="ParserException">Thrown when the program contains syntax errors.</exception>
        public override void ParseProgram(string program)
        {
            program += "\nint x"; // Ensures 'end' works by adding a declaration for 'x'
            string text = "";
            string[] array = program.Split('\n');
            Program.SyntaxOk = false;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Trim();
                if (array[i].Equals(""))
                {
                    continue;
                }

                try
                {
                    ICommand command = ParseCommand(array[i]);
                    if (command is Method)
                    {
                        Method method = (Method)command;
                        _ = method.MethodName;
                        command = ParseCommand(method.Type + " " + method.MethodName);
                        Program.Remove(command);
                        for (int j = 0; j < method.LocalVariables.Length; j++)
                        {
                            command = ParseCommand(method.LocalVariables[j]);
                            ((Evaluation)command).Local = true;
                            Program.Remove(command);
                        }
                    }
                }
                catch (BOOSEException ex)
                {
                    if (ex.Message.Length != 0)
                    {
                        string text2 = ex.Message + " " + (i + 1) + ".\n";
                        text += text2;
                        Program.SyntaxOk = false;
                    }
                }
            }

            text = text.Trim();
            if (text.Length != 0)
            {
                throw new ParserException(text);
            }
        }
    }
}
