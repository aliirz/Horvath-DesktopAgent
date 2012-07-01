using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace Horvath.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleSwitch_Click(object sender, RoutedEventArgs e)
        {
            ToggleSwitch tg = (ToggleSwitch)sender;
            if ((bool)tg.IsChecked)
            {
                codeBox.IsEnabled = false;
                progressRing.IsActive = true;

                if (!codeBox.Password.Equals(""))
                    _timer = new Timer(new TimerCallback(TakeAction), null, 0, 10000);
            }
            else
            {
                codeBox.IsEnabled = true;
                progressRing.IsActive = false;
                //_timer.Dispose();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }


        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Take some action based on the command that came from Merlin.
        /// </summary>
        private void TakeAction(object obj)
        {
            //progressRing.IsActive = true;
            SysOps ops = new SysOps();
            IntegrationProvider _provider = new IntegrationProvider("http://merlinserver.jit.su", codeBox.Password);
            Command command = _provider.GetCommand();
            if (command.id == 0) //means there is not command to execute.
            {
                //_timer.Change(3, 10000);
                Console.WriteLine("No command received.");
            }
            else
            {
                switch (command.command_text)
                {
                    case "lock":
                        ops.LockComputer();
                        _provider.SendConfirmation(command.id, true);
                        Console.WriteLine("Locked Computer now changing timer");
                        //_timer.Change(System.Threading.Timeout.Infinite, 5000);
                        break;
                    case "mail":
                        ops.SendMail(null, null, null, null);
                        _provider.SendConfirmation(command.id, true);
                        Console.WriteLine("Mail Sent now changing timer");
                        //_timer.Change(System.Threading.Timeout.Infinite, 5000);
                        break;
                    default:
                       Console.WriteLine("Invalid Command Saeen! :{)");
                        break;
                }
            }


        }

    }
}
