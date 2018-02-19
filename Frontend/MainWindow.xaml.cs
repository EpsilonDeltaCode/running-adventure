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
using Backend;
using Backend.Base;
using Backend.PointGeneration;
using Backend.RouteImage;
using Frontend.TestArea;
using Osrm.Client;
using Osrm.Client.Base;
using Osrm.Client.Models;
using Osrm.Client.Models.Requests;
using Osrm.Client.Models.Responses;


namespace Frontend
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

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            TestFunctions1 tests = new TestFunctions1();
            tests.test2();
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
