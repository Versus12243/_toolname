using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _toolname.Contracts;

namespace _toolname.Actions
{
    public class AllAction : BaseAction
    {
        public AllAction(IFileService service):base(service) { }

        public override async Task<IEnumerable<string>> ExecuteAsync(string start)
        {
            var result = await _service.GetFiles(start, "*.*");
            return result;
        }
    }
}