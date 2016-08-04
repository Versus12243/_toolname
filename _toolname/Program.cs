using _toolname.Actions;
using _toolname.Contracts;
using _toolname.HelpInfo;
using _toolname.Service;
using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _toolname
{
    class Program
    {
        private static IContainer Container { get; set; }

        private static readonly string[] _commandList = new string[]
        {
            "all",
            "cpp",
            "reversed1",
            "reversed2"
        };
        
        static Program()
        {
            AppDomain.CurrentDomain
                .UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                Console.WriteLine(exception.Message);
            }

            Environment.Exit(1);
        }

       
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentsException();
            }

            if (!Directory.Exists(args[0]))
            {
                throw new ArgumentsException();
            }

            if (args.Length < 2 || !_commandList.Contains(args[1].ToLower()))
            {
                throw new ArgumentsException();
            }

            string startDirectory = Path.GetFullPath(args[0]);
            string commandName = args[1].ToLower();
            string outputFile = (args.Length > 2) ? args[2] : "results.txt";

            ContainerSetup();

            var command = Container.ResolveNamed<ICommand>(commandName);
            var result = command.ExecuteAsync(startDirectory).Result;
            var saver = Container.Resolve<ISaveService>();
            saver.SaveResult(result, outputFile);
            Console.WriteLine("Results was saved in " + outputFile);
        }

        private static void ContainerSetup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<DiskSaveService>().As<ISaveService>();

            builder.RegisterType<CppAction>().Named<ICommand>("cpp");
            builder.RegisterType<AllAction>().Named<ICommand>("all");
            builder.RegisterType<Reversed1Action>().Named<ICommand>("reversed1");
            builder.RegisterType<Reversed2Action>().Named<ICommand>("reversed2");

            Container = builder.Build();
        }        
    }            
}
