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
    public class CppCommandTests
    {
        [Test()]
        public void CppCommandExecuteTest()
        {
            var filePath = TestSetup.FilePath;
            IFileService service = TestSetup.GetService();

            var command = new CppAction(service);
            var result = command.ExecuteAsync("D:").Result;

            var expectedResult = new List<string> { @"\SuccessRun\pm.fw.HomeController\Visual Micro\wew.cpp /" };

            Assert.AreEqual(expectedResult, result);

        }
    }
}