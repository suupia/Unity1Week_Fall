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

namespace Projects.UI.Scripts
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;


        [Inject]
        public void Construct(IFruitScore fruitScore)
        {
            scoreText.text = fruitScore.Value.ToString();
            this.UpdateAsObservable()
                .ObserveEveryValueChanged(_ => fruitScore.Value)
                .Subscribe(_ => scoreText.text = ScoreFormat(fruitScore.Value));
        }

        string ScoreFormat(long value) => $"Score : {value}";
    }
}