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
    /// Interaction logic for searchEntryWindow.xaml
    /// </summary>
    public partial class searchEntryWindow : Window
    {
        public searchEntryWindow(MainWindow mainWindow)
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbFindAsset findAsset = new DbFindAsset(this);
        }

        private void search_bar_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            
           
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            // back button to main screen

            MainWindow main = new MainWindow();

            main.ShowDialog();

            this.Close();
            
            
        }
    }
}
