using Game.StatePattern;

namespace Game.Manager
{
    public class GameManager
    {
        GameStateOwner owner;
        public void Init()
        {
            owner = new GameStateOwner();
            owner.Init();
            owner.ChangeState(GameState.Init);
        }
    }
}
