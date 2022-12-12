
using ScottishGlen.databaseConnection;
using System;
using System.Windows;
using MySql.Data.MySqlClient;
using DbConnection = ScottishGlen.databaseConnection.DbConnection;
using ScottishGlen.view;
using Google.Protobuf.WellKnownTypes;

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

            splashScreen splashScreen = new splashScreen();



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


            DbGetAll dbGetAll = new DbGetAll(this);

            // if user is not logged in then display an error message
            
            


        }

        private void addToDatabase_Click(object sender, RoutedEventArgs e)
        {
            DbAddThisAsset dbAdd = new DbAddThisAsset();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            // open searchEntryWindow

            searchEntryWindow searchEntryWindow = new searchEntryWindow(this);

            searchEntryWindow.Show();

            this.Close();
            




        }

        private void editAssets_Click(object sender, RoutedEventArgs e)
        {
            editEntryWindow entryWindow = new editEntryWindow();

            entryWindow.Show();
        }

  // check if user is logged in 

        

        
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            loginPage loginPage = new loginPage();

            loginPage.Show();


        }

        private void nist_btn_Click(object sender, RoutedEventArgs e)
        {
            VulnrabilityCheck check = new VulnrabilityCheck();

            // Api/cveDump to display on screen

            textBoxDisplay.Text = "file saved ";



        }
    }   

    }

