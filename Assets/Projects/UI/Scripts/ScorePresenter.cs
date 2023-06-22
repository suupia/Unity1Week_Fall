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
            scoreText.text = fruitScore.Amount.ToString();
            this.UpdateAsObservable()
                .ObserveEveryValueChanged(_ => fruitScore.Amount)
                .Subscribe(_ =>
                {
                    if (fruitScore.Amount >= 0)
                    {
                        scoreText.color = Color.black;
                    }
                    else
                    {
                        scoreText.color = new Color(132 / 255.0f, 17/ 255.0f, 17/ 255.0f);
                    }

                    scoreText.text = $"Score : {NumberFormatter.FormatNumber(fruitScore.Amount)}";
                });
        }

    }
}