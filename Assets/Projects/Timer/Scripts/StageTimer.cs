using System;
using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using UniRx;
using UnityEngine;
using VContainer;

#nullable enable
namespace Projects.Timer.Scripts
{
    public class StageTimer : IDisposable
    {
        public bool IsTimeUp => RemainingTime <= 0;
        public float RemainingTime { get; private set; }
        readonly float _timeLimit = 5;  // ToDo: Tmp

        readonly IGameStateManager _gameStateManager;
        IDisposable _timerSubscription;

        [Inject]
        public StageTimer(IGameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public void Dispose()
        {
            _timerSubscription.Dispose();
        }

        public void StartTimer()
        {
            RemainingTime = _timeLimit;
            _timerSubscription = Observable.Interval(TimeSpan.FromSeconds(1))
                .Where(_ => _gameStateManager.CurrentState == GameState.Game)
                .Subscribe(_ => RemainingTime--);

            this.ObserveEveryValueChanged(_ => _.IsTimeUp)
                .Where(isTimeUp => isTimeUp && _gameStateManager.CurrentState == GameState.Game)
                .Subscribe(_ => _gameStateManager.ChangeState(GameState.PreparingResult));
        }
    }
}