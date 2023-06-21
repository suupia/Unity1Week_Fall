namespace Projects. Score.Interfaces
{
    public interface IFruitScore
    {
        double Amount { get; }
        
        void IncreaseScore(double amount);
        void DecreaseScore(double amount);
    }
}