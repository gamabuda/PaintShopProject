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
        private Client _client;

        public UserPage(Authorization auth)
        {
            InitializeComponent();

            foreach(var item in MainWindow.db.Client)
            {
                if(item.AuthorizationID == auth.ID)
                {
                    FullnameBox.Text = $"{item.Name} {item.Surname}";
                    PhoneBox.Text = item.Phone;
                    _client = item;
                    MsgDrop(CheckHistory());
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
        }

        private bool CheckHistory()
        {
            List<Order> history = new List<Order>();

            foreach (var item in MainWindow.db.Order)
            {
                if (item.ClientID == _client.ID)
                {
                    history.Add(item);
                }
            }

            if (history.Count == 0)
                return false;

            HistoryListView.ItemsSource = history;
            return true;
        }

        public void MsgDrop(bool result)
        {
            if (result)
            {
                MsgStack.Visibility = Visibility.Collapsed;
                HistoryStack.Visibility = Visibility.Visible;
            }
            else
            {
                MsgStack.Visibility = Visibility.Visible;
                HistoryStack.Visibility = Visibility.Collapsed;
            }
                
        }
    }
}
