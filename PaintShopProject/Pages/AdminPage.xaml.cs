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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();

            OrderStatusListView.ItemsSource = MainWindow.db.OrderStatus.ToList();
            StatusComBox.ItemsSource = MainWindow.db.Status.ToList();
        }

        private void ChangeStBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderStatus test = (OrderStatus)OrderStatusListView.SelectedItem;
            OnChange(test);
        }

        private void OnChange(OrderStatus status)
        {
            MsgStack.Visibility = Visibility.Collapsed;
            EditStack.Visibility = Visibility.Visible;

            IdBox.Text = status.ID.ToString();
            AddressBox.Text = status.Order.Address;
            ProductBox.Text = status.Order.Product.Name;
            StatusComBox.SelectedItem = status.Status.Name;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderStatus test = (OrderStatus)OrderStatusListView.SelectedItem;

            Status status = (Status)StatusComBox.SelectedItem;
            test.Status = status;
            test.StatusID = status.ID;

            try
            {
                MainWindow.db.SaveChanges();
                OrderStatusListView.ItemsSource = MainWindow.db.OrderStatus.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
