using _toolname.Actions;
using _toolname.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _toolname.Tests;

namespace _toolname.Action.Tests
{
    [TestFixture()]
    public class Reversed2CommandTests
    {
        [Test()]
        public void Reversed2CommandExecuteTest()
        {
            var filePath = TestSetup.FilePath;
            IFileService service = TestSetup.GetService();

            var command = new Reversed2Action(service);
            var result = command.ExecuteAsync("D:");

            var expectedResult = new List<string> { @"ppc.wew\orciM lausiV\rellortnoCemoH.wf.mp\nuRsseccuS\" };

            Assert.AreEqual(expectedResult, result);
        }
    }
}