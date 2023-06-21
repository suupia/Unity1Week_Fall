using Level.Interfaces;
using  Projects. Score.Interfaces;
using UnityEngine;
using VContainer;

#nullable  enable
namespace  Projects.Score.Script
{
    public class FruitScore : IFruitScore
    {
        public long Value => _increasedScore - _decreasedScore;
        
        long _increasedScore;
        long _decreasedScore;
        
        ILevelManager _levelManager;
        
        [Inject]
        public FruitScore(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }
        
        public void IncreaseScore(int value)
        {
            _increasedScore += value;
            JudgeLevelUp(_increasedScore);
        }
        public void DecreaseScore(int value)
        {
            _decreasedScore += value;
        }
        
        
        // 以下は別クラスに切り出す予定
        bool isLevelUped;
        void JudgeLevelUp(long amount)
        {
            if(isLevelUped) return;
            if (amount >= 100)
            {
                _levelManager.LevelUp();
                Debug.Log($"LevelUp! CurrentLevel : {_levelManager.CurrentLevel}");
                isLevelUped = true;
            }
            
        }
        
    }
}