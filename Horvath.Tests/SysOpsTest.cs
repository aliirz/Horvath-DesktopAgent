using Horvath.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Horvath.Tests
{
    
    
    /// <summary>
    ///This is a test class for SysOpsTest and is intended
    ///to contain all SysOpsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SysOpsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SendMail
        ///</summary>
        [TestMethod()]
        public void SendMailTest()
        {
            SysOps target = new SysOps(); // TODO: Initialize to an appropriate value
            string to = string.Empty; // TODO: Initialize to an appropriate value
            string subj = string.Empty; // TODO: Initialize to an appropriate value
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            target.SendMail(to, subj, msg, fileName);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
