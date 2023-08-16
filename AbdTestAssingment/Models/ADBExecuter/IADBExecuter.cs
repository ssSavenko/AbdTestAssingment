using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBExecuter
{
    public interface IADBExecuter
    { 
        string ExecuteADBCommand(string command);
    }
}
