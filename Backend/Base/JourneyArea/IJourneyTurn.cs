namespace Backend.Base.JourneyArea
{
    public interface IJourneyTurn
    {
        TurnAction Action { get; }

        TurnDirection Direction { get; }
    }

    public enum TurnAction
    {
        Depart = 1,
        Accive = 2,
        Follow = 4,
        Turn = 8,
        TurnEndOfRoad = 16,
        EnterRoundabout = 32,
        LeaveRoundAbout = 64,
        Merge = 128
    }

    public enum TurnDirection
    {
        Straight = 1,
        Uturn = 2,
        Left = 4,
        Right = 8,
        SlightLeft = 16,
        SlightRight = 32,
        SharpLeft = 64,
        SharpRight = 128
    }
}