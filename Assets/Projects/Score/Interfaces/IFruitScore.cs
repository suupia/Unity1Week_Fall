namespace Projects. Score.Interfaces
{
    public interface IFruitScore
    {
        double Amount { get; }
        
        void IncreaseScore(double value);
        void DecreaseScore(double value);
    }
}