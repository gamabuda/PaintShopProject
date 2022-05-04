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
using System.Windows.Shapes;

namespace PaintShopProject
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private PaintProjectEntities _db;

        public AuthWindow()
        {
            InitializeComponent();

            _db = new PaintProjectEntities();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in _db.Authorization)
            {
                if(item.Login == LoginBox.Text && item.Password == PasswordBox.Password)
                {
                    new MainWindow(item).Show();
                    this.Close();
                }
            }

            MsgCard.Visibility = Visibility.Visible;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NameBox.Text == String.Empty || SurnameBox.Text == String.Empty || PhoneBox.Text == String.Empty || LoginRegBox.Text == String.Empty || PasswordRegBox.Password == String.Empty)
            {
                MsgBox.Text = "Все поля должны быть заполнены!";
                MsgCard.Visibility = Visibility.Visible;
                return;
            }

            foreach (var item in _db.Authorization)
            {
                if (item.Login == LoginRegBox.Text)
                {
                    MsgBox.Text = "Такой логин уже занят!";
                    MsgCard.Visibility = Visibility.Visible;
                    return;
                }
            }

            var auth = new Authorization()
            {
                ID = Guid.NewGuid(),
                Login = LoginRegBox.Text,
                Password = PasswordRegBox.Password,
                RoleID = 3
            };

            var client = new Client()
            {
                ID = Guid.NewGuid(),
                Name = NameBox.Text,
                Surname = SurnameBox.Text,
                Phone = PhoneBox.Text,
                AuthorizationID = auth.ID
            };

            try
            {
                _db.Authorization.Add(auth);
                _db.Client.Add(client);
                _db.SaveChanges();

                new MainWindow(auth).Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
