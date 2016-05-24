using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Thinktecture.IdentityModel.Client;

namespace DropboxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebServerAccess wa = new WebServerAccess();
        private TokenResponse token = null;
        public MainWindow()
        {
            InitializeComponent();
            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            if (token != null) btnLoad.IsEnabled = true;
            else btnLoad.IsEnabled = false;
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            dgDropbox.ItemsSource = await wa.LoadLogs();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            TokenResponse temp = wa.GetToken(txtUserName.Text, txtPassword.Text);
            if (!temp.IsError)
            {
                token = temp;
            }
            EnableDisableControls();
        }
    }
}
