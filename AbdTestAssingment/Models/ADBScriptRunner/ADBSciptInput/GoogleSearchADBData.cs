using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput
{
    public class GoogleSearchADBData : IADBScriptInputData
    {
        private string data;

        public GoogleSearchADBData()
        {
            data = "";
        }

        public GoogleSearchADBData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }

        public void SetData(string data)
        {
            this.data = data;
        }
    }
}
