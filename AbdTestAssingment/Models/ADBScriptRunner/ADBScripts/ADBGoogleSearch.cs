using AdbTestAssingment.Models.ADBExecuter;
using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner.ADBScripts
{
    public class ADBGoogleSearch : IADBScript
    {

        private string sciprt = "shell am start -n com.android.chrome/org.chromium.chrome.browser.ChromeTabbedActivity -d \"google.com\" --activity-clear-task";

        public void Execute()
        {
            ADBExecuter.ADBExecuter.Instance.ExecuteADBCommand(sciprt);
        }

        public void SetInputData(IADBScriptInputData data)
        {
            string queryData = data.GetData();

            if (!string.IsNullOrEmpty(queryData))
            {

                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString.Add("q", queryData);

                sciprt = $"shell am start -n com.android.chrome/org.chromium.chrome.browser.ChromeTabbedActivity -d \"google.com/search?{queryString.ToString()}\" --activity-clear-task";
            }
            else
            {
                sciprt = "shell am start -n com.android.chrome/org.chromium.chrome.browser.ChromeTabbedActivity -d \"google.com\" --activity-clear-task";
            }
        }
    }
}
