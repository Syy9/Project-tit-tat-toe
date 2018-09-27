using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UI.Window;
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
            var window = Managers.UI.GetUIWindow<UIResultWindow>();
            window.Init(winner);
            window.OnCloseEvent += OnClose;

            window.Show(UILayerType.Popup);
        }

        void OnClose()
        {
            Managers.UI.Close<UIResultWindow>();
            Managers.UI.Close<UIBordWindow>();
            Owner.ChangeState(GameStateType.Init);
        }

    }
}
