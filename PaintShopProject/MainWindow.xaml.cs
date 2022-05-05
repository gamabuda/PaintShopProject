using PaintShopProject.db;
using PaintShopProject.Pages;
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
using Color = PaintShopProject.db.Color;

namespace PaintShopProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Authorization Auth;
        public static PaintProjectEntities db = new PaintProjectEntities();

        public static List<Order> Orders = new List<Order>();

        public MainWindow(Authorization auth)
        {
            InitializeComponent();

            Auth = auth;

            if (Auth.RoleID == 1)
                AdminBadged.Visibility = Visibility.Visible;
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserPage(Auth));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderPage());
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminPage());
        }
    }
}
