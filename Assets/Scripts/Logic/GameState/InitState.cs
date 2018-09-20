using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UnityEngine;

namespace Game.StatePattern
{
    public class InitState : State<GameState, GameStateOwner>
    {
        public InitState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter()
        {
            Managers.UI.ShowStartWindow();
        }
    }
}
