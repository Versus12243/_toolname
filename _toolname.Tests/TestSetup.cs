using _toolname.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _toolname.Tests
{
    public static class TestSetup
    {
        public static List<string> FilePath
        {
            get
            {
                return new List<string>
                    {
                        @"\SuccessRun\pm.fw.HomeController\Visual Micro\wew.cpp"
                    };
            }
        }

        public static IFileService GetService()
        {
            return Mock.Of<IFileService>(s => s.GetFiles(
                It.IsAny<string>(), It.IsAny<string>()).Result == FilePath);
        }
    }
}
