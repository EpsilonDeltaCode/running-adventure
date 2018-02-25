using System.Collections.Generic;
using Backend.Base;
using Backend.Base.RouteInfo;

namespace Backend.RouteRequest
{
    public interface IRouteRequester
    {
        IList<IGeoCoordinate> Coordinates { get; set; }

        RouteInfoResponse RequestedResponse { get; }

        string RequestUrl { get; }

        bool RequestSuccessful { get; }

        bool TryExecuteRequest();
       
    }
}