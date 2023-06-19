

namespace Projects.GameSystem.Interfaces
{
    public enum GameState
    {
        Title,
        Game,
        Result
    }
    public interface IGameState
    {
        GameState CurrentState { get; set; }
    }
}