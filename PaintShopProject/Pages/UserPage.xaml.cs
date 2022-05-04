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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage(Authorization auth)
        {
            InitializeComponent();

            foreach(var item in MainWindow.db.Client)
            {
                if(item.AuthorizationID == auth.ID)
                {
                    FullnameBox.Text = $"{item.Name} {item.Surname}";
                    PhoneBox.Text = item.Phone;
                    return;
                }
            }

            foreach (var item in MainWindow.db.Employee)
            {
                if (item.AuthorizationID == auth.ID)
                {
                    FullnameBox.Text = $"{item.Name} {item.Surname}";
                    PhoneBox.Text = item.Phone;
                    AddressBox.Visibility = Visibility.Visible;
                    AddressBox.Text = $"{item.Shop.City.Name} {item.Shop.Address}";
                    return;
                }
            }

            ProdListView.ItemsSource = MainWindow.db.Order.ToList();
        }
    }
}
