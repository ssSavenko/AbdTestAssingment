using AdbTestAssingment.Models.ADBScriptRunner;
using AdbTestAssingment.Models.ADBScriptRunner.ADBSciptInput;
using AdbTestAssingment.Models.ADBScriptRunner.ADBScripts;
using AdbTestAssingment.Models.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdbTestAssingment.ViewModels
{

    public class MainWindowViewModel
    {
        private ICommand searchData;
        private ICommand shutDownProcesses;

        private IADBScriptRunner scriptRunner;
        private IADBScriptInputData scriptInputData;

        ProcessStartInfo procS = new ProcessStartInfo();

        public MainWindowViewModel()
        {
            scriptRunner = new ADBScriptRunner();

            shutDownProcesses = new DelegateCommand(ShutDownProcesses);
            searchData = new DelegateCommand(SearchData);
        }

        private void ShutDownProcesses()
        {
            scriptRunner.StopAllProcesses();
        }

        private void SearchData()
        {
            //Not optimal a little bit(but it allows us to use strategy pattern)
            scriptRunner.CurrentScript = new ADBGoogleSearch();
            scriptRunner.SetInputData(scriptInputData);
            scriptRunner.ExecuteScript();
        }

        public string QueryString
        {
            set
            {
                scriptInputData = new GoogleSearchADBData(value);
            }
        }


        public ICommand ShutDownProcessesCommand => shutDownProcesses;
        public ICommand SearchDataCommand => searchData;
    }
}
