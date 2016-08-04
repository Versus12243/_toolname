using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _toolname.Contracts;

namespace _toolname.Actions
{
    public abstract class BaseAction : ICommand
    {
        public abstract Task<IEnumerable<string>> ExecuteAsync(string start);

        protected IFileService _service;
        public BaseAction(IFileService service)
        {
            _service = service;
        }
    }
}
