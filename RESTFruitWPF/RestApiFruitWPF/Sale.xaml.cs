using Newtonsoft.Json;
using RestApiFruitWPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace RestApiFruitWPF
{
    /// <summary>
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Window
    {
        HttpClient httpClient = new HttpClient();

        public Sale()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7108/api/Fruits/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
        }

        private TextBlock GetTextBlock()
        {
            return TextBlock;
        }

        private void TotalBtn_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Inlines.Add(new LineBreak());
            TextBlock.Inlines.Add(new Run("--------------------------------------------"));
            decimal totalSale = Fruits.GetTotalSale();
            TextBlock.Inlines.Add(new Run("The TotalSale is: " + totalSale));
            TextBlock.Inlines.Add(new LineBreak());
        }
        private async void ListAllBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await httpClient.GetStringAsync("GetAllFruits");
                Response res = JsonConvert.DeserializeObject<Response>(response);

                fruitList.ItemsSource = res.fruits;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void Reset()
        {
            IdText.Text = "";
            WeightText.Text = "";
        }

        private async void SaleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IdText.Text) || string.IsNullOrEmpty(WeightText.Text))
            {
                MessageBox.Show("Please fill in all the TextBoxes");
                return;
            }

            try
            {
                int id = int.Parse(IdText.Text);
                decimal weight = decimal.Parse(WeightText.Text);

                var response = await httpClient.GetAsync($"GetFruitSaleByProductIDAndWeight/{id}/{weight}");
                response.EnsureSuccessStatusCode(); // 确保请求成功

                
                var responseContent = await response.Content.ReadAsStringAsync();
                Response res = JsonConvert.DeserializeObject<Response>(responseContent);

                fruitList.Visibility = Visibility.Visible;


                // 清空并显示销售信息
                //TextBlock.Inlines.Clear();
                TextBlock.Inlines.Add(new Run("ID: " + id));
                TextBlock.Inlines.Add(new LineBreak());
                TextBlock.Inlines.Add(new Run("The Weight is: " + weight));
                TextBlock.Inlines.Add(new LineBreak());
                TextBlock.Inlines.Add(new Run("The Price is: " + res.fruit.Price));
                TextBlock.Inlines.Add(new LineBreak());
                TextBlock.Inlines.Add(new Run("The ItemSale is: " + res.fruit.ItemSale(weight, res.fruit.Price)));
                TextBlock.Inlines.Add(new LineBreak());
                Fruits fruit = new Fruits(id, weight, res.fruit.Price);
                decimal itemSale = fruit.ItemSale(weight, res.fruit.Price);
                Fruits.AddToTotalSale(itemSale);
                MessageBox.Show("Sale successful!");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Reset();
            }
        }
    }
}
