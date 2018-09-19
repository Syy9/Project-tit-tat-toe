using Game.StatePattern;

namespace Game.Manager
{
    public class GameManager : BaseManager
    {
        GameStateOwner owner;
        public override void Init(Managers managers)
        {
            base.Init(managers);

            owner = new GameStateOwner();
            owner.Init(managers);
        }

        public void ActivateGame()
        {
            owner.ChangeState(GameState.Init);
        }
    }
}
