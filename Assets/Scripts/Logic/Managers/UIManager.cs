using System;
using System.Collections.Generic;
using Game.StatePattern;
using UI;
using UI.Lyaer;
using UI.Window;
using UnityEngine;

namespace Game.Manager
{
    public class UIManager : BaseManager
    {
        Dictionary<Type, UIWindow> Cache = new Dictionary<Type, UIWindow>();
        public override void Init(Managers managers)
        {
            base.Init(managers);
        }

        public T GetUIWindow<T>() where T : UIWindow
        {
            var type = typeof(T);
            T window = null;
            if(Cache.ContainsKey(type))
            {
                window = (T) Cache[type];
            } else {
                 window = UIController.Instance.GetUIWindow<T>();
                Cache[type] = window;
            }
            
            return window;
        }

        public void Close<T>() where T : UIWindow
        {
            var type = typeof(T);
            if (Cache.ContainsKey(type))
            {
                var window = Cache[type];
                window.Hide();
                Cache.Remove(type);
            }
        }
    }
}
