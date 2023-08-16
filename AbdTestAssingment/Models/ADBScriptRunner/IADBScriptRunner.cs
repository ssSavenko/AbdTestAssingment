using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using AdbTestAssingment.Models.ADBScriptRunner.ADBScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner
{
    internal interface IADBScriptRunner
    {
        IADBScript? CurrentScript { get; set; }

        void SetInputData(IADBScriptInputData data);

        void ExecuteScript();

        void StopAllProcesses();
    }
}
