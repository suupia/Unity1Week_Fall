namespace Projects. Score.Interfaces
{
    public interface IFruitScore
    {
        int Value { get; }
        
        void IncreaseScore(int value);
        void DecreaseScore(int value);
    }
}