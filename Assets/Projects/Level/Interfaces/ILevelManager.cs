namespace Level.Interfaces
{
    public interface ILevelManager
    {
        public int CurrentLevel { get; }
        public void LevelUp();
    }
}