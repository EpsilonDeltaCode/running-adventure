using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
using Backend.RouteImage;
using Backend.Services;
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
        private IList<IGeoCoordinate> _coordinates = new List<IGeoCoordinate>();

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            _coordinates = new List<IGeoCoordinate>()
            {
                new GeoCoordinate(Convert.ToDouble(tbLatitude1.Text.Replace(".", ",")), Convert.ToDouble(tbLongitude1.Text.Replace(".", ","))),
                new GeoCoordinate(Convert.ToDouble(tbLatitude2.Text.Replace(".", ",")), Convert.ToDouble(tbLongitude2.Text.Replace(".", ",")))
            };
            IRouteRequesterService requester = new OsrmRouteRequesterService();
            RouteInfoResponse response = requester.TryRequestRoute(_coordinates);
            CheckBoxA.IsChecked = requester.RequestSuccessful;
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            string url = TestingFunctions.GetOrsmObservableUrl(_coordinates);
            CheckBoxB.IsChecked = true;
            System.Diagnostics.Process.Start(url);
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            tbLatitude1.Text = Geography.CalculateDistance(_coordinates[0], _coordinates[1]).ToString(CultureInfo.InvariantCulture);
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonE_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
