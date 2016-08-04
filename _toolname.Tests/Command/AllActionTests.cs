using NUnit.Framework;
using _toolname.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using _toolname.Tests;
using _toolname.Contracts;
using _toolname.Actions;

namespace _toolname.Action.Tests
{
    [TestFixture()]
    public class AllCommandTests
    {
        [Test()]
        public void AllCommandExecuteTest()
        {
            var filePath = TestSetup.FilePath;
            IFileService service = TestSetup.GetService();

            var command = new AllAction(service);
            var result = command.ExecuteAsync("D:").Result;

            Assert.AreEqual(filePath, result);
        }
    }
}