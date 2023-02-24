using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SocketClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AsynchronousClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new AsynchronousClient();
            client.StartClient();
            Task.Run(WriteReceived);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.Send(client.client,textbox.Text);
            textbox.Text = "";
        }

        private async Task WriteReceived()
        {
            string lastResponse = null;
            while(true)
            {
                if (client.response != lastResponse)
                {
                    chat.Text = client.response;
                }
            }

        }
    }
}
