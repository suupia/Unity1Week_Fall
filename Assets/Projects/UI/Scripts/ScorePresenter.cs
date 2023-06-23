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
using Projects.Utility;

namespace Projects.UI.Scripts
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;

        [Inject]
        public void Construct(IFruitScore fruitScore)
        {
            // 初期化
            scoreText = ScoreFormatter.FormatScore(scoreText, fruitScore.Amount);
            
            
            this.UpdateAsObservable()
                .ObserveEveryValueChanged(_ => fruitScore.Amount)
                .Subscribe(_ =>
                {
                    scoreText = ScoreFormatter.FormatScore(scoreText, fruitScore.Amount);
                });
        }

    }
}