using System;
using Level.Interfaces;
using Projects.Score.Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

#nullable enable
namespace Projects.Score.Script
{
    public class FruitScore : IFruitScore
    {
        public double Amount => _increasedScore - _decreasedScore;

        double _increasedScore;
        double _decreasedScore;
        double _peakScore; // 到達したスコアの最大値 単調増加に鳴ることに注意

        readonly ILevelManager _levelManager;
        readonly JudgeLevelUp _judgeLevel;

        [Inject]
        public FruitScore(ILevelManager levelManager)
        {
            _levelManager = levelManager;
            _judgeLevel = new JudgeLevelUp(levelManager);
        }

        public void IncreaseScore(double value)
        {
            _increasedScore += value;
            _judgeLevel. UpdatePeakScore(Amount);
        }

        public void DecreaseScore(double value)
        {
            _decreasedScore += value;
            _judgeLevel. UpdatePeakScore(Amount);
        }
        
        
    }

    public class JudgeLevelUp
    {
        double _peakScore; // 到達したスコアの最大値 単調増加になることに注意
        readonly ILevelManager _levelManager;

        readonly Func<long, double> _levelUpJudge = (level) => Mathf.Pow(100, level); // レベルアップの成長曲線を決める

        public JudgeLevelUp(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void UpdatePeakScore(double amount)
        {
            _peakScore = _peakScore >= amount ? _peakScore : amount;
            if(_levelUpJudge(_levelManager.CurrentLevel) <= _peakScore) _levelManager.LevelUp();
        }
    }
}