using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Projects.GameSystem.Interfaces;
using Projects.Score.Interfaces;
using Projects.UI.Buttons.Scripts;
using Projects.Utility;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
public class ResultPresenter : MonoBehaviour
{
    [SerializeField] GameObject resultParent;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TwitterButtonController twitterButtonController;
    [SerializeField] RankingButtonController rankingButtonController;
    
    readonly float _waitTime = 2.2f;  // Result中にScoreが増えないようにするための待機時間
   
    [Inject]
    public void Construct(IGameStateManager gameStateManger, IFruitScore fruitScore)
    {
        Observable.EveryUpdate()
            .Where(_ => gameStateManger.CurrentState == GameState.PreparingResult)
            .Subscribe(_ => ShowResult(gameStateManger, fruitScore))
            .AddTo(this);
    }
    
    
    async  void ShowResult(IGameStateManager gameStateManger, IFruitScore fruitScore)
    {
        // awaitとUniTaskを使って_waitTimeだけ待機
        await UniTask.Delay(TimeSpan.FromSeconds(_waitTime));
        gameStateManger.ChangeState(GameState.Result);
        scoreText = ScoreFormatter.FormatScore(scoreText, fruitScore.Amount);
        resultParent.SetActive(true);
        
        // Twitterボタンのスコアをセット
        twitterButtonController.SetScore(fruitScore.Amount);
        
        // Rankingボタンのスコアをセット
        rankingButtonController.SetScore(fruitScore.Amount);
    }
}
