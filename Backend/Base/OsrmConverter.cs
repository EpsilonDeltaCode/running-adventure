using System.Collections.Generic;
using System.Linq;
using Backend.Base.RouteInfo;
using Osrm.Client.Base;
using Osrm.Client.Models;
using Osrm.Client.Models.Responses;

namespace Backend.Base
{
    public static class OsrmConverter
    {
        public static List<Location> ConvertGeocoordinatesToLocations(List<GeoCoordinate> coordinates)
        {
            List<Location> locations = new List<Location>();
            foreach (GeoCoordinate geoCoordinate in coordinates)
            {
                locations.Add(new Location(geoCoordinate.Latitude, geoCoordinate.Longitude));
            }

            return locations;
        }

        public static Location ConvertGeocoordinateToLocation(GeoCoordinate coordinate)
        {
            return new Location(coordinate.Latitude, coordinate.Longitude);
        }

        public static List<GeoCoordinate> ConvertLocationsToGeocoordinates(List<Location> locations)
        {
            List <GeoCoordinate> coordinates = new List<GeoCoordinate>();
            foreach (Location location in locations)
            {
                coordinates.Add(new GeoCoordinate(location.Latitude, location.Longitude));
            }

            return coordinates;
        }

        public static GeoCoordinate ConvertLocationToGeoCoordinate(Location location)
        {
            return new GeoCoordinate(location.Latitude, location.Longitude);
        }

        public static RouteInfoResponse ConvertRouteResponseToRouteInfoResponse(RouteResponse response)
        {
            RouteInfoResponse infoResponse = new RouteInfoResponse()
            {
                Waypoints = new List<RouteInfoWaypoint>(),
                Routes = new List<RouteInfoRoute>()
            };

            foreach (Waypoint waypoint in response.Waypoints)
            {
                infoResponse.Waypoints.Add(AddInfoWaypointFromWaypoint(waypoint));
            }

            foreach (Route route in response.Routes)
            {
                infoResponse.Routes.Add(AddInfoRouteFromRoute(route));
            }

            return infoResponse;
        }

        

        private static RouteInfoWaypoint AddInfoWaypointFromWaypoint(Waypoint waypoint)
        {
            RouteInfoWaypoint infoWaypoint = new RouteInfoWaypoint()
            {
                Distance = waypoint.Distance,
                Hint = waypoint.Hint,
                Coordinate = ConvertLocationToGeoCoordinate(waypoint.Location),
                Name = waypoint.Name,
                MatchingsIndex = waypoint.MatchingsIndex,
                TripsIndex = waypoint.TripsIndex,
                WaypointIndex = waypoint.WaypointIndex
            };
            return infoWaypoint;
        }

        private static RouteInfoRoute AddInfoRouteFromRoute(Route route)
        {
            RouteInfoRoute infoRoute = new RouteInfoRoute
            {
                Duration = route.Duration,
                Confidence = route.Confidence,
                Legs = new List<RouteInfoLeg>(),
                Geometry = ConvertLocationsToGeocoordinates(route.Geometry.ToList())
            };

            foreach (RouteLeg routeLeg in route.Legs)
            {
                infoRoute.Legs.Add(AddInfoLegFromLeg(routeLeg));
            }

            return infoRoute;
        }

        private static RouteInfoLeg AddInfoLegFromLeg(RouteLeg routeLeg)
        {
            RouteInfoLeg infoLeg = new RouteInfoLeg()
            {
                Distance = routeLeg.Distance,
                Duration = routeLeg.Duration,
                Summary = routeLeg.Summary,
                Steps = new List<RouteInfoStep>()
            };
            foreach (RouteStep step in routeLeg.Steps)
            {
                infoLeg.Steps.Add(AddInfoStepFromStep(step));
            }

            return infoLeg;
        }

        private static RouteInfoStep AddInfoStepFromStep(RouteStep step)
        {
            RouteInfoStep infoStep = new RouteInfoStep
            {
                Distance = step.Distance,
                Duration = step.Duration,
                Mode = step.Mode,
                Name = step.Name,
                Geometry = ConvertLocationsToGeocoordinates(step.Geometry.ToList()),
                Maneuver = ConvertRouteInfoManeuverFromManeuver(step.Maneuver)
            };

            return infoStep;
        }

        private static RouteInfoManeuver ConvertRouteInfoManeuverFromManeuver(StepManeuver maneuver)
        {
            RouteInfoManeuver infoManeuver = new RouteInfoManeuver()
            {
                BearingAfter = maneuver.BearingAfter,
                BearingBefore = maneuver.BearingBefore,
                Exit = maneuver.Exit,
                Coordinate = ConvertLocationToGeoCoordinate(maneuver.Location),
                Type = maneuver.Type,
                Modifier = maneuver.Modifier
            };

            return infoManeuver;
        }
    }
}
