using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner.ADBScripts
{
    public interface IADBScript
    {
        void SetInputData (IADBScriptInputData data);

        void Execute();
    }
}
