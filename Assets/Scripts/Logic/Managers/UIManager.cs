using System;
using Game.StatePattern;
using UI;

namespace Game.Manager
{
    public class UIManager : BaseManager
    {
        public Action OnSelectStartEvent;
        public override void Init(Managers managers)
        {
            base.Init(managers);
        }

        public void ShowStartWindow()
        {
            var window = UIController.Instance.Popup.GetUIWindow("StartWindow") as UIStartWindow;
            window.OnClick = OnSelectStartEvent;
            window.Show();
        }

        public void HideStartWindow()
        {
            var window = UIController.Instance.Popup.GetUIWindow("StartWindow") as UIStartWindow;
            window.OnClick = null;
            window.Hide();
        }
    }
}
