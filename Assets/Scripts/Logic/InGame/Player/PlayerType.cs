using System;
using UnityEngine;

public enum PlayerType
{
    None,
    Player1,
    Player2,
}

public static class PlayerTypeExtentions
{
    public static Color GetColor(this PlayerType self)
    {
        switch (self)
        {
            case PlayerType.None:
                return Color.white;
            case PlayerType.Player1:
                return Color.blue;
            case PlayerType.Player2:
                return Color.red;
            default:
                throw new NotImplementedException("Not Implemented GetColor. type=" + self);
        }
    }

    public static PlayerType GetNextPlayer(this PlayerType self)
    {
        switch (self)
        {
            case PlayerType.Player1:
                return PlayerType.Player2;
            case PlayerType.Player2:
                return PlayerType.Player1;
            default:
                throw new NotImplementedException("Not Implemented GetColor. type=" + self);
        }
    }
}
