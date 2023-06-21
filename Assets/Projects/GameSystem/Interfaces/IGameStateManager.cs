

namespace Projects.GameSystem.Interfaces
{
    public enum GameState
    {
        Title,
        Game,
        Result
    }
    public interface IGameStateManager
    {
        GameState CurrentState { get;  }
         void ChangeState(GameState state);
    }
}