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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ScottishGlen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void thisHardwareInformation_Click(object sender, RoutedEventArgs e)
        {
            importHardwareInformation hardwareInformation = new importHardwareInformation();

            textBoxDisplay.Text = hardwareInformation.ToString();
        }

        private void thisComputerInformation_Click(object sender, RoutedEventArgs e)
        {

            importSystemInformation systemInformation = new importSystemInformation();

            textBoxDisplay.Text = systemInformation.ToString();
        }
    }
}
