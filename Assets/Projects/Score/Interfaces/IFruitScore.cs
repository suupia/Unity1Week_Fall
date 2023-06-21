namespace Projects. Score.Interfaces
{
    public interface IFruitScore
    {
        long Value { get; }
        
        void IncreaseScore(int value);
        void DecreaseScore(int value);
    }
}