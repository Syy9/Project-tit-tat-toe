using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Window;
using UnityEngine;

namespace UI.Lyaer
{
    public class UILayer : MonoBehaviour
    {
        [SerializeField] List<UIWindow> RegisterUIList;
        Dictionary<Type, UIWindow> windowSource = new Dictionary<Type, UIWindow>();

        void Awake()
        {
            foreach (var uiWindow in RegisterUIList)
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

    [System.Serializable]
    public class UIRegister
    {
        public UIWindow UIWindow;
    }
}
