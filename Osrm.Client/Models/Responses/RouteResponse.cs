using System.Runtime.Serialization;

namespace Osrm.Client.Models.Responses
{
    [DataContract]
    public class RouteResponse : BaseResponse
    {
        /// <summary>
        /// Array of Waypoint objects representing all waypoints in order:
        /// </summary>
        [DataMember(Name = "waypoints")]
        public Waypoint[] Waypoints { get; set; }

        /// <summary>
        /// An array of Route objects, ordered by descending recommendation rank.
        /// </summary>
        [DataMember(Name = "routes")]
        public Route[] Routes { get; set; }
    }
}