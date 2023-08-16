using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using AdbTestAssingment.Models.ADBScriptRunner.ADBScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner
{
    internal class ADBScriptRunner : IADBScriptRunner
    {
        private readonly string getHomeScript = "adb shell am start -W -c android.intent.category.HOME -a android.intent.action.MAIN";
        private ADBCloseProcesses adbCloseProcessesScript;
        private IADBScript? currentScript; 

        public ADBScriptRunner()
        {
            try
            { 
                ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand("devices");
            }
            catch {
                throw new Exception("there are problem with adb");
            }

            adbCloseProcessesScript = new ADBCloseProcesses();
            currentScript = null;
        }

        public IADBScript? CurrentScript { get => currentScript; set => currentScript = value; }

        public void SetInputData(IADBScriptInputData data)
        {
            if (currentScript != null)
            {
                currentScript?.SetInputData(data);
            }
        }

        public void ExecuteScript()
        {
            if (currentScript != null)
            {
                MoveHome();
                currentScript?.Execute();
            }
        }

        public void StopAllProcesses()
        {
            MoveHome();
            adbCloseProcessesScript.Execute();
        }

        private void MoveHome()
        {
            ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(getHomeScript);
        }
    }
}
