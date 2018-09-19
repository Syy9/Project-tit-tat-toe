using Framework.StatePattern;
using Game.Manager;

namespace Game.StatePattern
{
    public enum GameState
    {
        Init,
        Game,
        Result,
    }
    public class GameStateOwner : Owner<GameState>
    {
        public void Init(Managers managers)
        {
            AddState(GameState.Init, new InitState(managers));
        }
    }
}
