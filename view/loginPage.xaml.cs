using ScottishGlen.databaseConnection;
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

namespace ScottishGlen.view
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Window
    {
        public loginPage()
        {
            InitializeComponent();
        }

        public void username_txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        public void password_txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            DbGetLogin login = new DbGetLogin();

            // if username and password are correct then open the main window

            if (login_btn.IsEnabled == true)
            {
                MainWindow main = new MainWindow();
                main.ShowDialog();
                Visibility = Visibility.Hidden;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
            {

            }

            // if username and password are incorrect then display an error message

           
        }

        private void loginSuccess()
        {
            
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            
        }
    }
}
