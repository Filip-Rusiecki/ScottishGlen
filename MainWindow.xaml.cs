
using ScottishGlen.databaseConnection;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

using MySql.Data.MySqlClient;
using DbConnection = ScottishGlen.databaseConnection.DbConnection;

namespace ScottishGlen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            // add splashscreen and load the components (import hardware + system + connect to db)
            InitializeComponent();


            // load the splash screen 
      


        }


            



        private void thisComputerInformation_Click(object sender, RoutedEventArgs e)
        {

                // imports system and hardware information then displays it in a textbox
                importHardwareInformation hardwareInformation = new importHardwareInformation();
                importSystemInformation systemInformation = new importSystemInformation();


                textBoxDisplay.Text = systemInformation.ToString()
                + hardwareInformation.ToString();

            // note: not all hardware info is needed

        }

        private void getAllAssets_Click(object sender, RoutedEventArgs e)
        {
            // get iformation from database and display it in a textbox

           DbConnection conn = new databaseConnection.DbConnection();
            DbGetAll getAll = new databaseConnection.DbGetAll(conn);

            textBoxDisplay.Text = getAll.ToString();
           

        }

    }

    }

