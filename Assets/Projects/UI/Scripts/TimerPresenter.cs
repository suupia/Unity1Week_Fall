using System.Collections;
using System.Collections.Generic;
using Projects.Stage.Scripts;
using UnityEngine;
using Projects.GameSystem.Scripts;
using Projects.GameSystem.Interfaces;
using VContainer;
using UniRx;
using UniRx.Triggers;
using TMPro;
using Projects.Score.Interfaces;
using Projects.Timer.Scripts;
using UnityEngine.Serialization;

namespace Projects.UI.Scripts
{
    public class TimerPresenter : MonoBehaviour
    {
       [SerializeField] TextMeshProUGUI timerText;


        [Inject]
        public void Construct(StageTimer stateTimer)
        {
            timerText.text = stateTimer.RemainingTime.ToString();
            this.UpdateAsObservable()
                .ObserveEveryValueChanged(_ => stateTimer.RemainingTime)
                .Subscribe(_ => timerText.text = TimerFormat(stateTimer.RemainingTime));
        }

        string TimerFormat(float value) => $"Time : {value} s";
    }
}