using EntityTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityNUnitTests
{
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbInit.DBInit();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            DbInit.DBInit().DbDispose();
        }
    }
}
