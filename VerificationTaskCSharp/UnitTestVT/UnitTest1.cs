using System;
using VerificationTaskCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestVT
{
    [TestClass]
    public class UnitTestReader
    {
        [TestMethod]
        [DeploymentItem("incorrect.txt")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void open_when_file_name_is_incorrect()
        {
            var testReader = new Reader("../../incorrect.txt");
            testReader.open();
        }

        [TestMethod]
        [DeploymentItem("correct.txt")]
        public void open_when_file_name_is_correct()
        {
            var testReader = new Reader("../../correct.txt");
            testReader.open();
            testReader.close();
        }

        [TestMethod]
        [DeploymentItem("correct.txt")]
        public void file_size_is_84_bytes()
        {
            var testReader = new Reader("../../correct.txt");
            testReader.open();
            var testSize =  testReader.getFileSize();
            testReader.close();

            Assert.AreEqual<long>(testSize, 84, "Size is incorrect!");
        }

        [TestMethod]
        [DeploymentItem("correct.txt")]
        public void element_is_Hello_and_space()
        {
            var testReader = new Reader("../../correct.txt");
            testReader.open();
            var testElement = testReader.getElement();
            testReader.close();

            Assert.AreEqual<string>(testElement[0], "Hello", "Word is incorrect!");
            Assert.AreEqual<string>(testElement[1], " ", "Divide is incorrect!");
        }
    }
}
