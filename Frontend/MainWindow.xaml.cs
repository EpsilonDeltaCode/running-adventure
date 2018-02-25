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
using Backend.Base.RouteInfo;
using Backend.PointGeneration;
using Backend.RouteImage;
using Backend.RouteRequest;
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

        private IRouteRequester _requester;
        private IList<IGeoCoordinate> _cleanedCoordinates = new List<IGeoCoordinate>();

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            _cleanedCoordinates = TestingFunctions.CalculateRandomCoordinatesAndMatchToStreetGrid();
            if (_cleanedCoordinates != null && _cleanedCoordinates.Count != 0)
            {
                CheckBoxA.IsChecked = true;
            }
            else
            {
                CheckBoxA.IsChecked = false;
            }
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            _requester = TestingFunctions.RequestARoute(_cleanedCoordinates);
            CheckBoxB.IsChecked = _requester.RequestSuccessful;
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            string url = TestingFunctions.GetOrsmObservableUrl(_cleanedCoordinates);
            System.Diagnostics.Process.Start(url);
            CheckBoxC.IsChecked = true;
            CheckBoxD.IsChecked = false;
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            string url = TestingFunctions.GetOrsmObservableUrlForFineCoordinates(_requester);
            System.Diagnostics.Process.Start(url);
            CheckBoxC.IsChecked = false;
            CheckBoxD.IsChecked = true;
        }
    }
}
