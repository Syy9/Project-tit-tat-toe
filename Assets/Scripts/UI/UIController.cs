using System;
using System.Collections;
using System.Collections.Generic;
using UI.Lyaer;
using UI.Window;
using UnityEngine;

namespace UI
{
    public class UIController : SingletonMonoBehaviour<UIController> {
        [SerializeField] List<UIWindow> uiWindowList;
        Dictionary<Type, UIWindow> windowSource = new Dictionary<Type, UIWindow>();
        public UILayer Content;
        public UILayer Popup;

        protected override void OnAwake()
        {
            foreach (var uiWindow in uiWindowList)
            {
                windowSource[uiWindow.GetType()] = uiWindow;
            }
        }

        public T GetUIWindow<T>() where T : UIWindow
        {
            var type = typeof(T);
            return windowSource.ContainsKey(type) ? windowSource[type] as T : null;
        }
    }
}
