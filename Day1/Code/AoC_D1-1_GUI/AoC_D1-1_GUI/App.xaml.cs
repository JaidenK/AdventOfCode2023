using AoC_D1_1_GUI.Model;
using AoC_D1_1_GUI.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AoC_D1_1_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if(e.Args.Length > 0)
            {
                Run_Headless(e);
            }
            else
            {
                var Wnd = new MainWindow();
                Wnd.Show();
            }
        }

        private void Run_Headless(StartupEventArgs e)
        {
            // Console.WriteLine won't show up in the actual command window
            // and I don't know why. Not worth trying to fix right now 
            // for this little AoC challenge so I'll just write the output
            // to a file.

            try
            {
                string input_filename = e.Args[0];
                string output_filename = e.Args.Length > 1 ? e.Args[1] : "out.txt";

                var lines = File.ReadAllLines(input_filename);
                var result = new AlphaNumericParser().ParseLines(lines);

                File.WriteAllText(output_filename, result.FullCalValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Application.Current.Shutdown();
        }
    }
}
