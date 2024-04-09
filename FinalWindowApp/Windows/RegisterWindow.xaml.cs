using BookstoreDBLib;
using BookstoreDBLib.Entities;
using BookStoreDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class RegisterWindow : Window
    {
        BookstoreDB context;

        public RegisterWindow()
        {
            InitializeComponent();
            context = new BookstoreDB();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string emailPattern = @"\w*@[a-z]{1,}[.][a-z]{1,}";
            string passwordPattern = @"\w{8}";
            Regex emailRegx = new Regex(emailPattern);
            Regex passwordRegx = new Regex(passwordPattern);


            if (String.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name Field Can't be empty.", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(SurnameTextBox.Text))
            {
                MessageBox.Show("Surname Field Can't be empty.", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!emailRegx.IsMatch(EmailTextBox.Text))
            {
                MessageBox.Show("Wrong email.", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!passwordRegx.IsMatch(PasswordBox.Password))
            {
                MessageBox.Show("Password must contain at least 8 characters.", "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    RegisterAndLogIn(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Register Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void RegisterAndLogIn(User user)
        {
            user.Id = context.Users.Max(u => u.Id) + 1;
            user.Name = NameTextBox.Text;
            user.Surname = SurnameTextBox.Text;
            user.Email = EmailTextBox.Text;
            user.Password = PasswordBox.Password;

            LoginManager.Register(context, user);
            bool res = LoginManager.LogIn(context, user);

            if (res)
            {
                Close();
            }
            else
            {
                throw new Exception("Email or password is incorrect.");
            }
        }
    }
}