using System;
using Game.StatePattern;
using UI;
using UI.Lyaer;
using UI.Window;
using UnityEngine;

namespace Game.Manager
{
    public class UIManager : BaseManager
    {
        public override void Init(Managers managers)
        {
            base.Init(managers);
        }

        public T GetUIWindow<T>() where T : UIWindow
        {
            return UIController.Instance.GetUIWindow<T>();
        }
    }
}
