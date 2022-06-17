using MyLib.Model;
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

namespace MyLib.MyWindows.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        library_dbEntities library = new library_dbEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void vouti_Click(object sender, RoutedEventArgs e)
        {
            if (isChecked())
            {
                try
                {
                    User user = library.User.FirstOrDefault(item => item.login == log_box.Text && item.password == pass_box.Password);
                    if (user != null)
                    {
                        if (user.role_id == 1)
                        {
                            AdminWindow.AdminWindow adminWindow = new AdminWindow.AdminWindow();
                            adminWindow.Show();
                            this.Close();
                        }
                        if (user.role_id == 2)
                        {
                            ReaderWindow.ReaderWindow readerWindow = new ReaderWindow.ReaderWindow();
                            readerWindow.Show();
                            this.Close();
                        }
                        if (user.role_id == 6)
                        {
                            LibmanWindow.LibmanWindow libmanWindow = new LibmanWindow.LibmanWindow();
                            libmanWindow.Show();
                            this.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка");
                }
            }
        }

        private bool isChecked()
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(log_box.Text))
            {
                error.AppendLine("Введите логин");
            }
            if (string.IsNullOrEmpty(pass_box.Password))
            {
                error.AppendLine("Введите пароль");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(), "Ошибка");

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
