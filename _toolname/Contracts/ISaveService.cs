using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _toolname.Contracts
{
    public interface ISaveService
    {
        void SaveResult(IEnumerable<string> results, string output);
    }
}
