using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HomeTasks_Pro_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private string message = "Дані отримані\n";
        private int currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.2);
            timer.Tick += timer_Tick;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await SimulateDatabaseConnectionAsync();

            InfoTextBox.Text += "Підключено до бази даних\n";

            timer.Start();
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
          
            timer.Stop();

            await SimulateDatabaseDisconnectionAsync();

            InfoTextBox.Text += "\nВідключено від бази даних\n";
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (currentIndex < message.Length)
            {
                InfoTextBox.Text += message[currentIndex++];
            }
            else
            {
                currentIndex = 0;
            }
        }

        private async Task SimulateDatabaseConnectionAsync()
        {      
            await Task.Delay(3000);
        }

        private async Task SimulateDatabaseDisconnectionAsync()
        {
            await Task.Delay(3000);
        }

     
    }
}
