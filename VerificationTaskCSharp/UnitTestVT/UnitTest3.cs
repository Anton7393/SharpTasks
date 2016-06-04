using System;
using VerificationTaskCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestVT
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        [DeploymentItem("correctOut.txt")]
        public void open_when_output_name_is_correct()
        {
            var testWriter = new Writer("../../correctOut.txt");
            testWriter.open();
        }

        [TestMethod]
        [DeploymentItem("correctOut.txt")]
        public void print_test_common()
        {
            var testReader = new Reader("../../correctOut.txt");
            var testWriter = new Writer("../../correctOut.txt");
            var testElement = new List<string>();

            testElement.Add("Test");
            testElement.Add(" ");
            testWriter.open();
            testWriter.printCommon(testElement);
            testReader.open();
            testElement = testReader.getElement();
            testReader.close();

            Assert.AreEqual<string>(testElement[0], "Test", "Common print is incorrect");
        }

        [TestMethod]
        [DeploymentItem("correctOut.txt")]
        public void print_test_bold()
        {
            var testReader = new Reader("../../correctOut.txt");
            var testWriter = new Writer("../../correctOut.txt");
            var testElement = new List<string>();

            testElement.Add("Test");
            testElement.Add(" ");
            testWriter.open();
            testWriter.printBold(testElement);
            testReader.open();
            testElement = testReader.getElement();
            testReader.close();

            Assert.AreEqual<string>(testElement[0], "<b><i>Test</i></b>", "Common print is incorrect");
        }
    }
}
