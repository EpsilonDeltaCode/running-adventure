using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Base;
using Backend.Base.JourneyArea;
using Backend.Base.RouteInfo;

namespace Backend.Services
{
    public class JourneyGeneratorService : IJourneyGeneratorService
    {
        public IJourney GenerateFromRouteInfoResponse(RouteInfoResponse response)
        {
            IList<IJourneyMainNode> mainNodes = new List<IJourneyMainNode>();

            IJourneyMainNode currentNode;

            for (int i = 0; i < (response.Routes[0].Legs.Count - 1); i++)
            {
                for (int j = 0; j < response.Routes[0].Legs[i].Steps.Count - 1; j++)
                {
                    var step = response.Routes[0].Legs[i].Steps[j];
                    IJourneyBaseNode node = new JourneyMainNode()
                    {
                        Position = new GeoCoordinate(step.Intersections[0].Coordinate),

                    };
                }
            }
        }
    }
}
