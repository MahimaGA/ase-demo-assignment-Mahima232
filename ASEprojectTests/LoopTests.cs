using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASEproject;
using BOOSE;

namespace ASEprojectTests
{
    /// <summary>
    /// Contains tests for various loop and conditional structures within the program.
    /// </summary>
    [TestClass]
    public class LoopTests
    {
        private AppCanvas canvas = null!;

        /// <summary>
        /// Initializes the test environment by creating a new AppCanvas instance.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            canvas = new AppCanvas();
        }

        /// <summary>
        /// Tests a simple if-else structure with nested conditions.
        /// Ensures the commands execute successfully without errors.
        /// </summary>
        [TestMethod]
        public void TestIfElseStructure_ShouldExecuteSuccessfully()
        {
            string command = @"
            int control = 50
            if control < 10
                if control < 5
                    pen 255,0,0
                else
                    pen 0,0,255
                end if
                circle 20
                rect 20,20
            else
                pen 0,255,0
                circle 100
                rect 100,100
            end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests an invalid if-else structure missing the 'end if' for a nested condition.
        /// Expects an exception to be thrown during execution.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestIfElseMissingEndIf_ShouldThrowException()
        {
            string command = @"
            int control = 50
            if control < 10
                if control < 5
                    pen 255,0,0
                else
                    pen 0,0,255
            circle 20
            rect 20,20
            else
                pen 0,255,0
                circle 100
                rect 100,100
            end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests an if statement with an undefined variable in the condition.
        /// Expects an exception to be thrown during execution.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestIfWithUndefinedVariable_ShouldThrowException()
        {
            string command = @"
            if control < 10
                pen 255,0,0
            end if";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests a while loop that decreases the height variable until a condition is met.
        /// Ensures the commands execute successfully without errors.
        /// </summary>
        [TestMethod]
        public void TestWhileLoopDecreasingHeight_ShouldExecuteSuccessfully()
        {
            string command = @"
            moveto 100,100
            int width = 9
            int height = 150
            pen 255,128,128
            while height > 50
                circle height
                height = height - 15
                if height < 100
                    pen 0,128,255
                end if
            end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests a while loop that does not execute because the initial condition is false.
        /// Ensures the program runs successfully without entering the loop.
        /// </summary>
        [TestMethod]
        public void TestWhileLoopNoExecution_ShouldExecuteSuccessfully()
        {
            string command = @"
            int height = 40
            while height > 50
                circle height
                height = height - 10
            end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests a while loop with an undefined variable in the condition.
        /// Expects an exception to be thrown during execution.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void TestWhileWithUndefinedVariable_ShouldThrowException()
        {
            string command = @"
            while height > 50
                circle height
                height = height - 10
            end while";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests a while loop that is missing the 'end while' statement.
        /// Expects an exception to be thrown during execution.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestWhileMissingEndWhile_ShouldThrowException()
        {
            string command = @"
            int height = 100
            while height > 50
                circle height
                height = height - 10
            pen 0,255,0
            moveto 50,50";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Tests a for loop that counts up with a positive step value.
        /// Ensures the commands execute successfully.
        /// </summary>
        [TestMethod]
        public void TestForLoopCountingUp_ShouldExecuteSuccessfully()
        {
            string command = @"
            pen 255,0,0
            moveto 200,200
            for count = 1 to 20 step 2
                circle count * 10
            end for";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }
    }

}