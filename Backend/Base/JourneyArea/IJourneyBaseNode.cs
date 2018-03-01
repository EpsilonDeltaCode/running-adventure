namespace Backend.Base.JourneyArea
{
    public interface IJourneyBaseNode
    {
        IGeoCoordinate Position { get; set; }

        IJourneyTurn Turn { get; set; }

        IJourneyConnectionLine NextLine { get; set; }

        IJourneyConnectionLine PreviousLine { get; set; }

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