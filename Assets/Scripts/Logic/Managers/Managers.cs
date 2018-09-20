namespace Game.Manager
{
    public class Managers
    {
        public GameManager Game = new GameManager();
        public UIManager UI = new UIManager();
        public CoroutineManager Coroutine = new CoroutineManager();

        public void Init()
        {
            Game.Init(this);
            UI.Init(this);
            Coroutine.Init(this);
        }
    }

    public interface IManager
    {
        void Init(Managers managers);
    }

    public abstract class BaseManager : IManager
    {
        protected Managers Managers { get; private set; }
        public virtual void Init(Managers managers)
        {
            Managers = managers;
        }
    }

}
