using System.Runtime.Serialization;

namespace Osrm.Client.Models.Responses
{
    [DataContract]
    public class TableResponse : BaseResponse
    {
        /// <summary>
        /// array of arrays that stores the matrix in row-major order. durations[i][j] gives the travel time from the i-th waypoint to the j-th waypoint. Values are given in seconds.
        /// </summary>
        [DataMember(Name = "durations")]
        public double[][] Durations { get; set; }

        /// <summary>
        /// array of Waypoint objects describing all sources in order
        /// </summary>
        [DataMember(Name = "sources")]
        public Waypoint[] Sources { get; set; }

        /// <summary>
        /// array of Waypoint objects describing all destinations in order
        /// </summary>
        [DataMember(Name = "destinations")]
        public Waypoint[] Destinations { get; set; }
    }
}