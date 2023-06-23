

namespace Projects.GameSystem.Interfaces
{
    public enum GameState
    {
        Title,
        Game,
        PreparingResult, // Resultに移行するまでの準備時間中はこのステートとなる
        Result
    }
    public interface IGameStateManager
    {
        GameState CurrentState { get;  }
         void ChangeState(GameState state);
    }
}