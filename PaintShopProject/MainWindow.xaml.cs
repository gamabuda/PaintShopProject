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
        public static PaintProjectEntities db = new PaintProjectEntities();

        private Authorization _auth;

        public MainWindow(Authorization auth)
        {
            InitializeComponent();

            _auth = auth;
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserPage(_auth));
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
    }
}
