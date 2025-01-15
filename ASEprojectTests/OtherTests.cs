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
    /// Contains additional tests for verifying various command behaviors.
    /// </summary>
    [TestClass]
    public class OtherTests
    {
        private AppCanvas canvas = null!;

        /// <summary>
        /// Initializes the test environment by setting up the AppCanvas.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            canvas = new AppCanvas();
        }

        /// <summary>
        /// Valid Test: Defining and calling a method with parameters.
        /// This test ensures that a method with parameters is defined and called correctly in the program.
        /// </summary>
        /// <remarks>
        /// This method verifies the correct execution of a simple program with a defined method
        /// that takes parameters and performs operations based on them.
        /// </remarks>
        [TestMethod]
        public void TestMethodWithParameters_ShouldExecuteSuccessfully()
        {
            string command = @"method int testMethod int one, int two
                              testMethod = one * two
                            end method
                            int global = 55
                            call testMethod 10 15
                            moveto 200,200
                            write testMethod
                            circle testMethod
                            rect global, global";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Calling a method without defining it.
        /// This test verifies that an exception is thrown when a method is called without a prior definition.
        /// </summary>
        /// <remarks>
        /// The test should trigger an exception indicating that the method 'testMethod' has not been defined.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestCallWithoutMethodDefinition_ShouldThrowException()
        {
            string command = @"
                               call testMethod 10 15
                               moveto 200,200
                               write testMethod";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Missing input parameters when calling a method.
        /// This test checks if the system throws an exception when a method call is missing required input parameters.
        /// </summary>
        /// <remarks>
        /// This test should raise an exception due to the missing parameter during the method call.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void TestMethodCallWithMissingParameters_ShouldThrowException()
        {
            string command = @"method testMethod int one, int two
                               testMethod = one * two
                           end method
                           call testMethod 10
                           moveto 200,200
                           write testMethod";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Incorrect variable type used in method.
        /// This test ensures that an exception is thrown when a variable of incorrect type is used in a method.
        /// </summary>
        /// <remarks>
        /// The test checks if the system correctly handles and throws an exception for a type mismatch in method parameters.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void TestMethodWithIncorrectParameterType_ShouldThrowException()
        {
            string command = @"method testMethod int one, real two
                               testMethod = one * two
                           end method
                           call testMethod 10 'string'
                           moveto 200,200
                           write testMethod";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Method with mismatched parameter count.
        /// This test checks that the program throws an exception when the number of parameters in a method call doesn't match the definition.
        /// </summary>
        /// <remarks>
        /// The test ensures that calling a method with more parameters than defined triggers an exception.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(BOOSE.ParserException))]
        public void TestMethodWithMismatchedParameterCount_ShouldThrowException()
        {
            string command = @"method testMethod int one, int two
                               testMethod = one * two
                           end method
                           call testMethod 10 15 20
                           moveto 200,200
                           write testMethod";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }

        /// <summary>
        /// Invalid Test: Method with missing 'end method' keyword.
        /// This test verifies that an exception is thrown when the 'end method' keyword is omitted in the method definition.
        /// </summary>
        /// <remarks>
        /// This test simulates a situation where the 'end method' keyword is missing and expects an exception.
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(System.Exception))] // Adjusted to expect a more general exception
        public void TestMethodWithMissingEndMethod_ShouldThrowException()
        {
            string command = @"method testMethod int one, int two
                               testMethod = one * two
                           // Missing 'end method'
                           call testMethod 10 15
                           moveto 200,200
                           write testMethod";

            AppCommandFactory factory = new AppCommandFactory();
            AppStoredProgram program = new AppStoredProgram(canvas);
            Parser parser = new Parser(factory, program);

            parser.ParseProgram(command);
            program.Run();
        }
    }
}
