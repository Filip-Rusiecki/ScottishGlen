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
    /// Interaction logic for splashScreen.xaml
    /// </summary>
    public partial class splashScreen : Window
    {
        public splashScreen()
        {
            InitializeComponent();
            // close after 5 seconds

            System.Threading.Thread.Sleep(5000);

            this.Close();

            // open login page

            loginPage login = new loginPage();

            login.Show();

            


        }
    }
}
