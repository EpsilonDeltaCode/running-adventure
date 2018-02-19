using System.Collections.Generic;
using Backend.Base.RouteInfo;

namespace Backend.Base
{
    public interface IRouteRequester
    {
        List<GeoCoordinate> Coordinates { get; set; }

        RouteInfoResponse RequestedResponse { get; }

        bool RequestSuccessful { get; }

        void TryExecuteRequest();
       
    }
}