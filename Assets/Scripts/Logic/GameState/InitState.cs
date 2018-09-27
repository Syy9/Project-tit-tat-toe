using System.Collections;
using Framework.StatePattern;
using Game.Manager;
using UI;
using UnityEngine;

namespace Game.StatePattern
{
    public class InitState : State<GameStateType, GameStateOwner>
    {
        public InitState(Managers managers, GameStateOwner owner) : base(managers, owner)
        {
        }

        public override void OnEnter()
        {
            Managers.Coroutine.Call(Process());
        }

        IEnumerator Process()
        {
            var uiStartWindow = Managers.UI.GetUIWindow<UIStartWindow>();
            bool isDone = false;
            uiStartWindow.OnClick += () => {
                isDone = true;
            };
            uiStartWindow.Show(UILayerType.Popup);
            yield return new WaitUntil(() => isDone);
            Managers.UI.Close<UIStartWindow>();
            Owner.ChangeState(GameStateType.Game);
        }
    }
}
