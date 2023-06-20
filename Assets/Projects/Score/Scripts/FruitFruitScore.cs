using  Projects. Score.Interfaces;
#nullable  enable
namespace  Projects.Score.Script
{
    public class FruitFruitScore : IFruitScore
    {
        public int Value { get; private set; }
        
        public void IncreaseScore(int value)
        {
            Value += value;
        }
        public void DecreaseScore(int value)
        {
            Value -= value;
        }
    }
}