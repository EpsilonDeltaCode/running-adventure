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
        public static IList<Location> ConvertGeocoordinatesToLocations(IEnumerable<IGeoCoordinate> coordinates)
        {
            return coordinates.Select(gc => new Location(gc.Latitude, gc.Longitude)).ToList();
        }

        public static Location ConvertGeocoordinateToLocation(GeoCoordinate coordinate)
        {
            return new Location(coordinate.Latitude, coordinate.Longitude);
        }

        public static IList<GeoCoordinate> ConvertLocationsToGeocoordinates(IEnumerable<Location> locations)
        {
            return locations.Select(location => new GeoCoordinate(location.Latitude, location.Longitude)).ToList();
        }

        public static GeoCoordinate ConvertLocationToGeoCoordinate(Location location)
        {
            return new GeoCoordinate(location.Latitude, location.Longitude);
        }

        public static RouteInfoResponse ConvertRouteResponseToRouteInfoResponse(RouteResponse response)
        {
            var waypoints = response.Waypoints.Select(AddInfoWaypointFromWaypoint).ToList();
            var routes = response.Routes.Select(AddInfoRouteFromRoute).ToList();

            return new RouteInfoResponse(waypoints, routes);
        }

        

        private static RouteInfoWaypoint AddInfoWaypointFromWaypoint(Waypoint waypoint)
        {
            return new RouteInfoWaypoint
            {
                Distance = waypoint.Distance,
                Hint = waypoint.Hint,
                Coordinate = ConvertLocationToGeoCoordinate(waypoint.Location),
                Name = waypoint.Name,
                MatchingsIndex = waypoint.MatchingsIndex,
                TripsIndex = waypoint.TripsIndex,
                WaypointIndex = waypoint.WaypointIndex
            };
        }

        private static RouteInfoRoute AddInfoRouteFromRoute(Route route)
        {
            var legs = route.Legs.Select(AddInfoLegFromLeg).ToList();

            return new RouteInfoRoute
            {
                Distance = route.Distance,
                Duration = route.Duration,
                Confidence = route.Confidence,
                Legs = legs,
                Geometry = ConvertLocationsToGeocoordinates(route.Geometry.ToList())
            };
        }

        private static RouteInfoLeg AddInfoLegFromLeg(RouteLeg routeLeg)
        {
            var steps = routeLeg.Steps.Select(AddInfoStepFromStep).ToList();

            return new RouteInfoLeg
            {
                Distance = routeLeg.Distance,
                Duration = routeLeg.Duration,
                Summary = routeLeg.Summary,
                Steps = steps
            };
        }

        private static RouteInfoStep AddInfoStepFromStep(RouteStep step)
        {
            var intersections = step.Intersections.Select(AddInfoIntersectionFromIntersection).ToList();

            return new RouteInfoStep
            {
                Intersections = intersections,
                Distance = step.Distance,
                Duration = step.Duration,
                Mode = step.Mode,
                Name = step.Name,
                Geometry = ConvertLocationsToGeocoordinates(step.Geometry.ToList()),
                Maneuver = ConvertRouteInfoManeuverFromManeuver(step.Maneuver)
            };
        }

        private static RouteInfoManeuver ConvertRouteInfoManeuverFromManeuver(StepManeuver maneuver)
        {
            return new RouteInfoManeuver
            {
                BearingAfter = maneuver.BearingAfter,
                BearingBefore = maneuver.BearingBefore,
                Exit = maneuver.Exit,
                Coordinate = ConvertLocationToGeoCoordinate(maneuver.Location),
                Type = maneuver.Type,
                Modifier = maneuver.Modifier
            };
        }

        private static RouteInfoIntersection AddInfoIntersectionFromIntersection(StepIntersection stepIntersection)
        {
            return new RouteInfoIntersection
            {
                OutAngle = stepIntersection.OutAngle,
                InAngle = stepIntersection.InAngle,
                Entries = (bool[]) stepIntersection.Entries.Clone(),
                Bearings = (int[])stepIntersection.Bearings.Clone(),
                Coordinate = ConvertLocationToGeoCoordinate(stepIntersection.Location)
            };
        }
    }
}
