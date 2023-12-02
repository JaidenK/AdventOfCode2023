using AoC_D1_1_GUI.Core;
using AoC_D1_1_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AoC_D1_1_GUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Interface
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Bindings

        private string inputText = "Enter input here";
        public string InputText { get => inputText; set => SetProperty(ref inputText, value); }

        private string outputText;
        public string OutputText { get => outputText; set => SetProperty(ref outputText, value); }

        #endregion

        #region Commands

        private RelayCommand executeCmd;

        public ICommand ExecuteCmd
        {
            get
            {
                if (executeCmd == null)
                {
                    executeCmd = new RelayCommand(PerformExecuteCmd);
                }

                return executeCmd;
            }
        }

        private void PerformExecuteCmd(object commandParameter)
        {
            var result = new AlphaNumericParser().ParseLines(InputText.Split(new char[] { '\n' }));

            OutputText = result.FullCalValue.ToString();

            Console.WriteLine($"Sum of calibration values: {OutputText}");
        }

        #endregion

        public MainViewModel()
        {
        }
    }
}
