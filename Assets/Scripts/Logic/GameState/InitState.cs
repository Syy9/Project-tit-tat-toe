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
            Managers.Coroutine.Call(Process());
        }

        IEnumerator Process()
        {
            Managers.UI.ShowStartWindow();
            bool isDone = false;
            Managers.UI.OnSelectStartEvent += () => {
                isDone = true;
            };
            yield return new WaitUntil(() => isDone);
            Managers.UI.HideStartWindow();
            Managers.UI.OnSelectStartEvent = null;
            Owner.ChangeState(GameState.Game);
        }
    }
}
