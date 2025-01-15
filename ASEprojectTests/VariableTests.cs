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
    /// Contains the variable methods test
    /// </summary>

    [TestClass]
    public class VariableTests
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
        /// Tests a simple integer variable assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestIntVariableAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"int side = 40
                           int height
                           height = 3 * side
                           pen 0,255,0
                           moveto 150,150
                           rect side, height";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }

        /// <summary>
        /// Tests simple real variable assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestRealVariableAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"real base = 12.75
                           real height = 7.2
                           real area = 0.5 * base * height
                           pen 128,0,128
                           moveto 50,50
                           write area";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }

        /// <summary>
        /// Tests simple array assignment and usage.
        /// </summary>
        [TestMethod]
        public void TestArrayAssignment_ShouldExecuteSuccessfully()
        {
            string command = @"array int values 5
                           poke values 2 = 75
                           int result
                           peek result = values 2
                           circle result";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Should execute without exceptions
        }

        /// <summary>
        /// Tests array out-of-bounds access, expecting an exception due to invalid index.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestArrayOutOfBounds_ShouldThrowException()
        {
            string command = @"array int values 5
                           poke values 1 = 30
                           int result
                           peek result = values 10";  // Index 10 is out of bounds for the array

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Expecting exception
        }

        /// <summary>
        /// Tests an array with an invalid data type (assigning a real value to an int array).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.StoredProgramException))]
        public void TestArrayTypeMismatch_ShouldThrowException()
        {
            string command = @"array int values 5
                           poke values 3 = 42.58";  // Attempt to store a real value in an int array

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();  // Expecting exception
        }

    }
}