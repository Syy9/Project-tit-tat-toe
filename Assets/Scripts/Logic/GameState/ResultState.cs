using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UnityEngine;

namespace Game.StatePattern
{
    public class ResultState : State<GameStateType, GameStateOwner>
    {
        public ResultState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter(object arg)
        {
            var winner = (PlayerType) arg;
            Debug.Log("winner : " + winner);
        }

    }
}
