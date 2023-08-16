using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBExecuter
{
    public class ADBExecuter : IADBExecuter
    {
        public static ADBExecuter Instance = new ADBExecuter();


        private ProcessStartInfo processStartInfo;

        private ADBExecuter()
        {

            processStartInfo = new ProcessStartInfo();

            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.FileName = "adb";
        }


        public string ExecuteADBCommand(string command)
        {
            string resultValue = "";

            processStartInfo.Arguments = command;

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();


                resultValue = process.StandardOutput.ReadToEnd();
            }

            return resultValue;
        }

    }
}
