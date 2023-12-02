using AoC_D1_1_GUI.Core;
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
            string[] input = InputText.Split(new char[] { '\n' });

            int sum = 0;

            foreach (var s in input)
            {
                sum += ParseCalibrationValue(s.Trim());
            }

            OutputText = sum.ToString();

            Console.WriteLine($"Sum of calibration values: {sum}");
        }

        #endregion

        public MainViewModel()
        {
        }

        private static int ParseCalibrationValue(string input)
        {
            int firstDigit = -1;
            int lastDigit = -1;

            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    int digit = int.Parse(c.ToString());
                    if (firstDigit < 0)
                    {
                        firstDigit = digit;
                    }
                    lastDigit = digit;
                }
            }

            int calibration_value = 10 * firstDigit + lastDigit;

            Console.WriteLine($"{input} -> {calibration_value}");

            return calibration_value;
        }
    }
}
