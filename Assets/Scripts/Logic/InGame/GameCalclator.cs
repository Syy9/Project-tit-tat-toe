using UnityEngine;
using System.Linq;
public class GameCalclator : IGameCalclator
{
    private static readonly int HORIZONTAL_COUNT = 3;
    private static readonly int VERTICAL_COUNT = 3;
    Bord[] Bords;
    public GameCalclator(Bord[] bords)
    {
        Bords = bords;
    }

    public Result CalcResult()
    {
        for (int i = 0; i < HORIZONTAL_COUNT; i++)
        {
            var result = CalcResultHorizontal(i);
            if(result.IsDone)
            {
                return result;
            }
        }

        for (int i = 0; i < VERTICAL_COUNT; i++)
        {
            var result = CalcResultVertical(i);
            if (result.IsDone)
            {
                return result;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            var result = CalcResultDiagonal(i == 0);
            if (result.IsDone)
            {
                return result;
            }
        }
        return Result.CreateNotDone();
    }

    /// <summary>
    /// Calc Horizontal Align Result
    /// </summary>
    /// <param name="row">0 ~ </param>
    /// <returns></returns>
    Result CalcResultHorizontal(int row)
    {
        var bords = new Bord[HORIZONTAL_COUNT];
        for (int i = 0; i < bords.Length; i++)
        {
            bords[i] = Bords[i + (row * bords.Length)];
        }
        return CalcResult(bords);
    }

    /// <summary>
    /// Calc Vertical Align Result
    /// </summary>
    /// <param name="column">0 ~ </param>
    /// <returns></returns>
    Result CalcResultVertical(int column)
    {
        var bords = new Bord[VERTICAL_COUNT];
        for (int i = 0; i < bords.Length; i++)
        {
            bords[i] = Bords[(i * bords.Length) + column];
        }
        return CalcResult(bords);
    }

    /// <summary>
    /// Calc Diagonal Align Result
    /// </summary>
    /// <param name="isLeftToBottom"></param>
    /// <returns></returns>
    Result CalcResultDiagonal(bool isLeftToBottom)
    {
        if(HORIZONTAL_COUNT != VERTICAL_COUNT)
        {
            Debug.LogError("Not Supported BordCount. Require Equal HORIZONTAL_COUNT and VERTICAL_COUNT.");
            return Result.CreateNotDone();
        }

        var bords = new Bord[VERTICAL_COUNT];
        if(isLeftToBottom)
        {
            for (int i = 0; i < bords.Length; i++)
            {
                bords[i] = Bords[i + (bords.Length * i)];
            }
        } else {
            for (int i = 0; i < bords.Length; i++)
            {
                bords[i] = Bords[(bords.Length * i) + bords.Length - i -1];
            }
        }

        return CalcResult(bords);
    }

    Result CalcResult(Bord[] alignedBords)
    {
        var owner = alignedBords.First().Owner;
        if(owner == PlayerType.None)
            return Result.CreateNotDone();

        var isDone = alignedBords.All(b => b.Owner == owner);
        if(isDone)
        {
            return Result.CreateDone(owner);
        } else {
            return Result.CreateNotDone();
        }
    }
}

public interface IGameCalclator
{
    Result CalcResult();
}

public class Result
{
    public bool IsDone;
    public PlayerType Winner;
    public static Result CreateNotDone()
    {
        var instance = new Result();
        instance.IsDone = false;
        instance.Winner = PlayerType.None;
        return instance;
    }

    public static Result CreateDone(PlayerType winner)
    {
        var instance = new Result();
        instance.IsDone = true;
        instance.Winner = winner;
        return instance;
    }
}
