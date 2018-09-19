using System;
using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Framework.StatePattern
{
    public abstract class State
    {
        protected Managers Managers { get; private set; }
        public State(Managers managers)
        {
            Managers = managers;
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
    }

    public abstract class Owner<TEnum>
    {
        Dictionary<TEnum, State> stateList = new Dictionary<TEnum, State>();
        State currentState;
        public void AddState(TEnum stateType, State state)
        {
            stateList.Add(stateType, state);
        }

        public void ChangeState(TEnum stateType)
        {
            if (!stateList.ContainsKey(stateType))
            {
                Debug.Log("Not found state. stateType=" + stateType.ToString());
                return;
            }

            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = stateList[stateType];
            currentState.OnEnter();
        }
    }
}
