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

namespace DiplomnaCarProject
{
    /// <summary>
    /// Interaction logic for Login2.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        LoginClass login = new LoginClass();

        public Login2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = TBusername.Text.ToString();
            Singletone.LogedUser = username;
            string password = TBpassword.Password.ToString();

            if (login.Log(username, password) == true)
            {
                Singletone.userID = login.getUserID(username, password);
                Singletone.LogedUser = login.getUsername(Singletone.userID);
                Singletone.uRole = login.getRole(username, password);

                navigation navigation = new navigation(this);
                navigation.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Невалидно потребителско име , парола или деактивиран акаунт");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TBusername.Focus();
            this.Title = "Вход в системата";
        }
    }
}
