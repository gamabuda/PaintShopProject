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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            CheckOrder("Ваша корзина пуста :(", "Выберите подходящий вам товар из списка нашего каталога.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AddressBox.Text == string.Empty)
            {
                AddressBox.BorderBrush = Brushes.Red;
                return;
            }

            foreach(var item in MainWindow.Orders)
            {
                item.ClientID = item.Client.ID;
                item.ProductID = item.Product.ID;
                item.Address = AddressBox.Text;

                var orderStatus = new OrderStatus()
                {
                    ID = Guid.NewGuid(),
                    OrderID = item.ID,
                    EmployeeID = Guid.Parse("e7140562-adc2-41c4-a1a9-1e41bacbb16c"),
                    StatusID = Guid.Parse("cf68b0c7-4d31-4484-b494-ea20ad674d8b")
                };

                try
                {
                    MainWindow.db.Order.Add(item);
                    MainWindow.db.OrderStatus.Add(orderStatus);
                }
                catch
                {
                    MessageBox.Show("fdf");
                }
            }

            MainWindow.db.SaveChanges();
            MainWindow.Orders.Clear();

            CheckOrder("Ваш заказ в обработке :)", "После того как заказ пройдет обработку, он направится к вам.");
        }

        private void CheckOrder(string title, string msg)
        {
            if (MainWindow.Orders.Count == 0)
            {
                MsgBlock.Text = msg;
                TitleBlock.Text = title;

                MsgStack.Visibility = Visibility.Visible;
                MainStack.Visibility = Visibility.Collapsed;
            }
            else
            {
                MsgStack.Visibility = Visibility.Collapsed;
                MainStack.Visibility = Visibility.Visible;

                OrderListView.ItemsSource = MainWindow.Orders;
            }
        }
    }
}
