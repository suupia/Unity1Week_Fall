using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
#nullable enable
namespace Projects.Timer.Scripts
{
    public class StageTimer : IDisposable
    {
        public bool IsTimeUp => RemainingTime <= 0;
        public float RemainingTime { get; private set; }
        readonly float _timeLimit = 60;
        


        IDisposable _timerSubscription;

        public void Dispose()
        {
            _timerSubscription.Dispose();
        }

        public void StartTimer()
        {
            RemainingTime = _timeLimit;
            _timerSubscription = Observable.EveryUpdate()
                .ThrottleFirst(TimeSpan.FromSeconds(Time.deltaTime))
                .Subscribe(_ => RemainingTime -= Time.deltaTime);
        }
    }
}