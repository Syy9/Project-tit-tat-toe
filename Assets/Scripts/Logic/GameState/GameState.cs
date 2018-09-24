using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UnityEngine;

namespace Game.StatePattern
{
    public class GameState : State<GameStateType, GameStateOwner>
    {
        public GameState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter()
        {
            var window = Managers.UI.GetUIWindow<UIBordWindow>();
            window.Show(UILayerType.Content);
        }
    }
}
