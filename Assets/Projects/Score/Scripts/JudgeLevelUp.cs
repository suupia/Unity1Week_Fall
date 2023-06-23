using System;
using Level.Interfaces;
using UnityEngine;
using VContainer;

namespace Projects.Score.Script
{
    public class JudgeLevelUp
    {
        double _peakScore; // 到達したスコアの最大値 単調増加になることに注意
        readonly ILevelManager _levelManager;

        readonly Func<long, double> _levelUpJudge = (level) => 10 + 10 * Mathf.Pow(5, level); // レベルアップの成長曲線を決める

        [Inject]
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