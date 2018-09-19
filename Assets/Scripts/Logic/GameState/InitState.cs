using Framework.StatePattern;
using Game.Manager;
using UnityEngine;

namespace Game.StatePattern
{
    public class InitState : State
    {
        public InitState(Managers managers) : base(managers)
        {
        }

        public override void OnEnter()
        {
            Managers.UI.ShowStartWindow();
        }
    }
}
