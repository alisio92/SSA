using Newtonsoft.Json;
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
using Zoekertjes.Models;

namespace ZoekertjesApp
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //await Load();

            //om de load methode uit de WebserviceAcces klasse te gebruiken
            WebserviceAcces webservice = new WebserviceAcces();
            await webservice.Load();
            await webservice.LoadCategories();
            await webservice.LoadLocaties();
            //lstZoekers.ItemsSource = webservice.Load().Result;
            lstZoekers.ItemsSource = webservice.result;

            cboCategorie.ItemsSource = webservice.resultCat;
            cboLocatie.ItemsSource = webservice.resultLoc;
        }

        private async Task Load()
        {
            string url = "http://localhost:2519/api/values/";

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string json = await response.Content.ReadAsStringAsync();
                    List<Zoekertje> result = JsonConvert.DeserializeObject<List<Zoekertje>>(json);
                    lstZoekers.ItemsSource = result;
                }

            }
        }
    }
}
