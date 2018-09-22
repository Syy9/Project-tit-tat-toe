using System;
using System.Collections;
using System.Collections.Generic;
using UI.Lyaer;
using UI.Window;
using UnityEngine;

namespace UI
{
    public class UIController : SingletonMonoBehaviour<UIController> {
        [SerializeField] RectTransform cacheRoot;
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
            var prefab = windowSource.ContainsKey(type) ? windowSource[type] as T : null;
            var uiWindow = GameObject.Instantiate(prefab);
            uiWindow.transform.SetParent(cacheRoot, false);
            uiWindow.gameObject.SetActive(false);
            return uiWindow;
        }

        public UILayer GetUILayer(UILayerType type)
        {
            switch (type)
            {
                case UILayerType.Content:
                    return UIController.Instance.Content;
                case UILayerType.Popup:
                    return UIController.Instance.Popup;
            }

            return null;
        }
    }

    public enum UILayerType
    {
        Content,
        Popup,
    }
}
