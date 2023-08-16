using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput
{
    public interface IADBScriptInputData
    {
        string GetData();
        void SetData(string data);
    }
}
