using System.Collections;
using Framework.StatePattern;
using Game.Manager;
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
            uiStartWindow.Show();
            yield return new WaitUntil(() => isDone);
            uiStartWindow.Hide();
            uiStartWindow.OnClick = null;
            Owner.ChangeState(GameStateType.Game);
        }
    }
}
