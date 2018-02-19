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
using Backend.PointGeneration;
using Backend.RouteImage;
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

            /*
            Osrm5x osrm = new Osrm5x("http://router.project-osrm.org/");

            OnCircleRandomPointGenerator generator = new OnCircleRandomPointGenerator()
            {
                MetricCircumFerence = 5000.0,
                CircleDirection = 0,
                HomePoint = new GeoCoordinate(50.116883, 8.660157),
                NumberOfPoints = 10
            };

            List<GeoCoordinate> points = generator.GeneratePoints();

            List<GeoCoordinate> cleanedPoints = new List<GeoCoordinate>();
            foreach (GeoCoordinate geoCoordinate in points)
            {
                NearestResponse nearestResponse = osrm.Nearest(new Location[] { geoCoordinate.ToLocation() });
                cleanedPoints.Add(new GeoCoordinate(nearestResponse.Waypoints[0].Location.Latitude, nearestResponse.Waypoints[0].Location.Longitude));
            }


            ProjectOsrmUrlGenerator linkgen = new ProjectOsrmUrlGenerator()
            {
                Zoom = 8,
                LanguageString = "en",
                AlternativeRoutes = false
            };


            TextBoxA.Text = linkgen.GenerateFullLink(points);
            TextBoxB.Text = linkgen.GenerateFullLink(cleanedPoints);
            // WebBrowser1.Navigate(linkgen.GenerateFullLink(points));




            Location[] locations = new Location[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                locations[i] = points[i].ToLocation();
            }


            for (int i = 0; i < cleanedPoints.Count - 1; i++)
            {
                Location[] locPoints = new[] {cleanedPoints[i].ToLocation(), cleanedPoints[i+1].ToLocation() };

                RouteResponse response = osrm.Route(new RouteRequest()
                {
                    Coordinates = locPoints,
                    Steps = true,
                    Alternative = false
                });
            }

            */

            /*

            RouteResponse response = osrm.Route(new RouteRequest()
            {
                Coordinates = locations,
                Steps = true,
                Alternative = false
            });

            foreach (RouteLeg routeLeg in response.Routes[0].Legs)
            {
                foreach (RouteStep routeStep in routeLeg.Steps)
                {
                    Console.WriteLine("Go " + (int)routeStep.Distance + "m on " + routeStep.Name + " and then " + routeStep.Maneuver.Type + " " + routeStep.Maneuver.Modifier + "!");
                }
            }

             */

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
