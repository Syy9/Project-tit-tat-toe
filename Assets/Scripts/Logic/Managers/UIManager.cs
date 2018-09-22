using System;
using Game.StatePattern;
using UI;
using UI.Lyaer;
using UI.Window;

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

        UILayer GetUILayer(UILayerType type)
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
