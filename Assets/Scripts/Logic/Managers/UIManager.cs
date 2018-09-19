using Game.StatePattern;
using UI;

namespace Game.Manager
{
    public class UIManager : BaseManager
    {
        public override void Init(Managers managers)
        {
            base.Init(managers);
        }

        public void ShowStartWindow()
        {
            var window = UIController.Instance.Popup.GetUIWindow("StartWindow");
            window.Show();
        }
    }
}
