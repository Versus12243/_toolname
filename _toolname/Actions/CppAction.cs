using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _toolname.Contracts;

namespace _toolname.Actions
{
    public class CppAction : BaseAction
    {
        public CppAction(IFileService service):base(service) { }

        public override async Task<IEnumerable<string>> ExecuteAsync(string start)
        {
            var files = await _service.GetFiles(start, "*.cpp");
            return files.Select(s => s + " /");
        }
    }
}
