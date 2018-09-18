using Framework.StatePattern;
using UnityEngine;

namespace Game.StatePattern
{
    public class InitState : State
    {
        public override void OnEnter()
        {
            Debug.Log("InitState - OnEnter");
        }
    }
}
