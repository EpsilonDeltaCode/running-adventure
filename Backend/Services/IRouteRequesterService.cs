using System.Collections.Generic;
using Backend.Base;
using Backend.Base.RouteInfo;

namespace Backend.Services
{
    public interface IRouteRequesterService
    {
        RouteInfoResponse TryRequestRoute(IList<IGeoCoordinate> coordinates);

        bool RequestSuccessful { get; }
    }
}