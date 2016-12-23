using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var hubConnection = new HubConnection("http://localhost:8080");
            IHubProxy myHub = hubConnection.CreateHubProxy("MyHub");
            myHub.On<string>("SayHello", SayHello);
            await hubConnection.Start();
        }

        void SayHello(string myString)
        {
            textBlock.Dispatcher.Invoke(() =>
            {
                textBlock.Text = myString;
            });
            
        }
    }
}
