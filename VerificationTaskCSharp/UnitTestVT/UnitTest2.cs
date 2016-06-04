using System;
using VerificationTaskCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestVT
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        [DeploymentItem("incorrectD.txt")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void open_when_dictionary_name_is_incorrect()
        {
            var testDictionary = new Dictionary("../../incorrectD.txt");
            testDictionary.start();
        }

        [TestMethod]
        [DeploymentItem("correctD.txt")]
        public void open_when_dictionary_name_is_correct()
        {
            var testDictionary = new Dictionary("../../correctD.txt");
            testDictionary.start();
        }

        [TestMethod]
        [DeploymentItem("correctD.txt")]
        public void dictionary_size_is_50_bytes()
        {
            var testDictionary = new Dictionary("../../correctD.txt");
            testDictionary.start();
            var testSize = testDictionary.getFileSize();


            Assert.AreEqual<long>(testSize, 50, "Size is incorrect!");
        }

        [TestMethod]
        [DeploymentItem("correctD.txt")]
        public void dictionary_include()
        {
            var testDictionary = new Dictionary("../../correctD.txt");
            testDictionary.start();

            Assert.IsTrue(testDictionary.compare("Hello"), "Dictionary contains Hello");
            Assert.IsTrue(testDictionary.compare("world!"), "Dictionary contains world!");
            Assert.IsTrue(testDictionary.compare(":)"), "Dictionary contains :)");
            Assert.IsFalse(testDictionary.compare("world"), "Dictionary don't contains world");
            Assert.IsFalse(testDictionary.compare("are"), "Dictionary don't contains are");
            Assert.IsFalse(testDictionary.compare("Reader"), "Dictionary don't contains Reader");
        }
    }
}
