using PaintShopProject.db;
using System;
using System.Collections.Generic;
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

namespace PaintShopProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private Client _client;

        public ProductPage()
        {
            InitializeComponent();

            foreach (var item in MainWindow.db.Client)
            {
                if (item.AuthorizationID == MainWindow.Auth.ID)
                    _client = item;
            }

            ProdListView.ItemsSource = MainWindow.db.Product.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var ourBtn = sender as Button;
            var product = Guid.Parse(ourBtn.CommandParameter.ToString());

            MainWindow.Orders.Add(new Order()
            {
                ID = Guid.NewGuid(),
                Product = MainWindow.db.Product.FirstOrDefault(c=> c.ID == product),
                Date = DateTime.Now,
                Client = _client,
                Count = 1
            });
            
        }
    }
}
