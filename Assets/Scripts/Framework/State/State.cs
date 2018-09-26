using System;
using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

namespace Framework.StatePattern
{
    public abstract class State
    {
        public virtual void OnEnter() { }
        public virtual void OnEnter(object arg) { }
        public virtual void OnExit() { }
    }
    public abstract class State<TEnum,TOwner> : State where TOwner : Owner<TEnum>
    {
        protected Managers Managers { get; private set; }
        protected TOwner Owner { get; private set; }
        public State(Managers managers, TOwner owenr)
        {
            Managers = managers;
            Owner = owenr;
        }
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
            currentState = ExitAndGetState(stateType);
            currentState.OnEnter();
        }

        public void ChangeState(TEnum stateType, object arg)
        {
            currentState = ExitAndGetState(stateType);
            currentState.OnEnter(arg);
        }

        State ExitAndGetState(TEnum stateType)
        {
            if (!stateList.ContainsKey(stateType))
            {
                Debug.Log("Not found state. stateType=" + stateType.ToString());
                return null;
            }

#if UNITY_EDITOR
            Debug.Log("Change State " + stateType.ToString());
#endif

            if (currentState != null)
            {
                currentState.OnExit();
            }

            var newState = stateList[stateType];
            return newState;
        }
    }
}
