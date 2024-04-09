using BookstoreDBLib;
using BookstoreDBLib.Entities;
using BookStoreDBLib;
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

namespace FinalWindowApp.Windows
{
    public partial class LoginWindow : Window
    {
        BookstoreDB context;
        public LoginWindow()
        {
            InitializeComponent();
            context = new BookstoreDB();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try{
                LogIn();
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogIn()
        {
            User user = new User();
            user.Email = EmailTextBox.Text;
            user.Password = PasswordBox.Password;

            bool res = LoginManager.LogIn(context, user);

            if (!res)
            {
                throw new Exception("Email or password is incorrect.");
            }
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
