using System;
using VerificationTaskCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestVT
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        [DeploymentItem("correct.txt")]
        [DeploymentItem("correctD.txt")]
        [DeploymentItem("testout.html")]
        public void actor_test()
        {
            var testActor = new Actor();

            testActor.setPathToDictionary("../../correctD.txt");
            testActor.setPathToInputFile("../../correct.txt");
            testActor.setPathToOutputFile("../../testout.html");

            testActor.start();
        }
    }
}
