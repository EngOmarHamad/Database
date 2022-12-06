using Game_Store.Helpers;
using Game_Store.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Game_Store
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


            if (txtPassWord.Password.Length == 0)
            {
                lblPasswordeErorr.Height = Double.NaN;
                lblPasswordeErorr.Content = "Password is requird";

            }
            else
            {
                lblPasswordeErorr.Height = 0;
                lblPasswordeErorr.Content = "";
            }
            if (txtUserName.Text.Length == 0)

            {
                lblUserNameErorr.Height = Double.NaN;
                lblUserNameErorr.Content = "UserName is requird";

            }
            else
            {
                lblUserNameErorr.Height = 0;
                lblUserNameErorr.Content = "";
            }

            if (txtPassWord.Password.Length == 0 || txtUserName.Text.Length == 0)
                return;
            users users = new users() { username = txtUserName.Text, password = Convert.ToInt32(txtPassWord.Password) };

            if (SignInHelper.Login(users) > 0)
            {
                SplachScreen splachScreen = new SplachScreen();
                splachScreen.Show();
            }
            else MessageBox.Show(" Error In Login");


        }

        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignIN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
