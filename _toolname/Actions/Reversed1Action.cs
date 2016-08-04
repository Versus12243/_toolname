using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _toolname.Contracts;

namespace _toolname.Actions
{
    public class Reversed1Action : BaseAction
    {
        public Reversed1Action(IFileService service):base(service) { }

        public override async Task<IEnumerable<string>> ExecuteAsync(string start)
        {
            var result = await _service.GetFiles(start, "*.*");
            return result.Select(f => string.Join(@"\", f.Split('\\').Reverse())); ;
        }
    }
}
