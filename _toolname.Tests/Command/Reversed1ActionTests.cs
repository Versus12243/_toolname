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
    public class Reversed1CommandTests
    {
        [Test()]
        public void Reversed1CommandExecuteTest()
        {
            var filePath = TestSetup.FilePath;
            IFileService service = TestSetup.GetService();

            var command = new Reversed1Action(service);
            var result = command.ExecuteAsync("D:");

            var expectedResult = new List<string> { @"wew.cpp\Visual Micro\pm.fw.HomeController\SuccessRun" };
            

            Assert.AreEqual(expectedResult, result);
        }
    }
}