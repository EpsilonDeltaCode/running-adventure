namespace Backend.Base.JourneyArea
{
    public interface IJourneyMarker
    {
        IGeoCoordinate Position { get; set; }

        JourneyMarkerType Type { get; set; }

        IJourneyTurn Turn { get; set; }

        IJourneyMarkerConnectionLine NextLine { get; set; }

        IBearing BearingIn { get; set; }

        IBearing BearingOut { get; set; }
    }

    public enum JourneyMarkerType
    {
        Start = 1,
        End = 2,
        Intersection = 4,
        PointOfInterest = 8,
        RoundaboutIn = 16,
        RoundaboutOut = 32,

    }
}