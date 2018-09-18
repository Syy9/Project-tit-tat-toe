using Framework.StatePattern;
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
        public void Init()
        {
            AddState(GameState.Init, new InitState());
        }
    }
}
