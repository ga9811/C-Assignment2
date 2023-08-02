using Newtonsoft.Json;
using RestApiFruitWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
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

namespace RestApiFruitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient httpClient = new HttpClient();
        public MainWindow()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7108/api/Fruits/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();
        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Fruits fruit = new Fruits();
            fruit.ProductName = ProductName.Text;
            fruit.ProductID = int.Parse(ProductID.Text);
            fruit.Amount = decimal.Parse(Amount.Text);
            fruit.Price = decimal.Parse(Price.Text);

            var response = await httpClient.PostAsJsonAsync("AddFruit", fruit);


            //  Response res = JsonConvert.DeserializeObject<Response>(response.Content.ToString());
            //  Responselb.Visibility = Visibility.Visible;
            //  Responselb.Content = res.statusCode + " " + res.message;

        }

        private async void SearchBtn_Click(object sender, RoutedEventArgs e)
        {


            var response = await httpClient.GetStringAsync("GetFruitByProductID/" + int.Parse(ProductID.Text));
            Response res = JsonConvert.DeserializeObject<Response>(response);
            
            Responselb.Visibility= Visibility.Visible;
            Responselb.Content = res.statusCode + " " + res.message;

            ProductName.Text = res.fruit.ProductName;
            ProductID.Text = res.fruit.ProductID.ToString();
            Amount.Text = res.fruit.Amount.ToString();
            Price.Text= res.fruit.Price.ToString();

          


        }

        private async void ListAllBtn_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetAllFruits");
            Response res = JsonConvert.DeserializeObject<Response>(response);
            Responselb.Visibility = Visibility.Visible;
            Responselb.Content = res.statusCode + " " + res.message;
            fruitList.ItemsSource = res.fruits;
            DataContext = this;

        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Fruits fruit = new Fruits();
            fruit.ProductName = ProductName.Text;
            fruit.ProductID = int.Parse(ProductID.Text);
            fruit.Amount = decimal.Parse(Amount.Text);
            fruit.Price = decimal.Parse(Price.Text);

            var response = await httpClient.PutAsJsonAsync("GetFruitUpdateByProductID", fruit);
            MessageBox.Show(response.StatusCode.ToString());
        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.DeleteAsync("DeleteFruitByProductID/"+ int.Parse(ProductID.Text));
            MessageBox.Show(response.ToString());
        }

        private void SaleBtn_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = new Sale();
            sale.Show();
            this.Close();
        }
    }
    }

