using System.Runtime.Serialization;

namespace Osrm.Client.Models.Responses
{
    [DataContract]
    public class NearestResponse : BaseResponse
    {
        /// <summary>
        /// Array of Waypoint objects representing all waypoints in order:
        /// </summary>
        [DataMember(Name = "waypoints")]
        public Waypoint[] Waypoints { get; set; }
    }
}