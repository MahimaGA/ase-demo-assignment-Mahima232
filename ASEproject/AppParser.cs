using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppParser : Parser, IParser
    {
        private CommandFactory Factory;
        private StoredProgram Program;

        public AppParser(CommandFactory Factory, StoredProgram Program) : base(Factory, Program)
        {
            this.Factory = Factory;
            this.Program = Program;
        }

        public override void ParseProgram(string program)
        {
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
