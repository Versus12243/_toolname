using _toolname.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _toolname.Service
{
    public class FileService: IFileService
    {
        public async Task<IEnumerable<string>> GetFiles(string root, string extension)
        {
            List<string> result = new List<string>();

            await Task.Run(() => {              

                Stack<string> dirs = new Stack<string>();               

                if (!System.IO.Directory.Exists(root))
                {
                    throw new ArgumentException();
                }
                dirs.Push(root);

                while (dirs.Count > 0)
                {
                    string currentDir = dirs.Pop();
                    string[] subDirs;
                    try
                    {
                        subDirs = System.IO.Directory.GetDirectories(currentDir);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    catch (System.IO.DirectoryNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    string[] files = null;

                    try
                    {
                        files = System.IO.Directory.GetFiles(currentDir, extension);
                    }
                    catch (UnauthorizedAccessException e)
                    {

                        Console.WriteLine(e.Message);
                        continue;
                    }
                    catch (System.IO.DirectoryNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    foreach (string file in files)
                    {
                        try
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(file);
                            result.Add(fi.FullName);
                        }
                        catch (System.IO.FileNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }

                    foreach (string str in subDirs)
                        dirs.Push(str);
                }
            });

            return result;
        }
    }
}
