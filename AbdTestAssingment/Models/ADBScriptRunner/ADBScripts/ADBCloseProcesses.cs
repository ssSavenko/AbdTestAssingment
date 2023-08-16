using AdbTestAssingment.Models.ADBExecuter;
using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner.ADBScripts
{
    public class ADBCloseProcesses : IADBScript
    {
        private readonly string getProccesesCountString = "shell dumpsys activity recents";
        private readonly string openRecentAppsString = "shell input keyevent KEYCODE_APP_SWITCH";
        private readonly string selectRecentAppString = "shell input keyevent 20";
        private readonly string deleteSelectedString = "shell input keyevent DEL";

        private readonly string taskKeyWord = "RecentTaskInfo #"; 

        public ADBCloseProcesses()
        { 
        }

        public void Execute()
        {
            int countProcesses = GetVisualProcessesCount(); 

            ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(openRecentAppsString);
            ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(selectRecentAppString); 

            for(int i = 0; i <= countProcesses; i++)
            {
                CloseProcess();
            }
        }

        private void CloseProcess()
        {
            ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(deleteSelectedString);
        }
         

        private int GetVisualProcessesCount()
        {
            int resultValue= 0;  
             
            string resultString = ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(getProccesesCountString);

            resultValue = ProcessStringParser(resultString);

            return resultValue;
        }

        private int ProcessStringParser(string processString)
        {
            int resultValue = 0;


            int a  = processString.LastIndexOf(taskKeyWord);

            if (a != -1)
            {
                var x = processString.Substring(a + taskKeyWord.Length);

                resultValue = int.Parse(x.Split(':')[0]) + 1;
            }

            return resultValue;
        }

        public void SetInputData(IADBScriptInputData data)
        {

        }
    }
}
