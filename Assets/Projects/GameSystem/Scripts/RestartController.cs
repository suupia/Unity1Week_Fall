using System;
using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class RestartController : MonoBehaviour
{

    [Inject]
    public void Construct(IGameStateManager gameStateManger)
    {
        Observable.EveryUpdate()
            .Where(_ => gameStateManger.CurrentState == GameState.Game ||
                        gameStateManger.CurrentState == GameState.PreparingResult ||
                        gameStateManger.CurrentState == GameState.Result)
            .Where(_ => Input.GetKeyDown(KeyCode.Escape))
            .Subscribe(_ => RestartGame())
            .AddTo(this);
    }

    void RestartGame()
    {
        // 現在のシーン名で読み込み
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
