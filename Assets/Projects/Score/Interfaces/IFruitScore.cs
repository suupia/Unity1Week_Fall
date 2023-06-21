namespace Projects. Score.Interfaces
{
    public interface IFruitScore
    {
        double Amount { get; }
        
        void IncreaseScore(int value);
        void DecreaseScore(int value);
    }
}