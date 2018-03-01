using Backend.Base.JourneyArea;
using Backend.Base.RouteInfo;

namespace Backend.Services
{
    public interface IJourneyGeneratorService
    {
        IJourney GenerateFromRouteInfoResponse(RouteInfoResponse response);
    }
}
