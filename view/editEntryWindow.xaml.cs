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
    /// Interaction logic for editEntryWindow.xaml
    /// </summary>
    public partial class editEntryWindow : Window
    {
        public editEntryWindow()
        {
            InitializeComponent();
            DbUpdateThisAsset update = new DbUpdateThisAsset(this);
        }



        private void hardwareInfo_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void systemName_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Os_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ipAddress_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void manufacturer_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void deviceType_textBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void serialNumber_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void notes_textBoxTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
