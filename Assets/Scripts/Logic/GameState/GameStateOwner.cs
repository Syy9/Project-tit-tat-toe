﻿using Framework.StatePattern;
using Game.Manager;

namespace Game.StatePattern
{
    public enum GameStateType
    {
        Init,
        Game,
        Result,
    }
    public class GameStateOwner : Owner<GameStateType>
    {
        public void Init(Managers managers)
        {
            AddState(GameStateType.Init, new InitState(managers, this));
            AddState(GameStateType.Game, new GameState(managers, this));
            AddState(GameStateType.Result, new ResultState(managers, this));
        }
    }
}
