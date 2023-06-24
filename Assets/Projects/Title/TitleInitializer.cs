using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class TitleInitializer : MonoBehaviour
{
    IGameStateManager _gameStateManager;
    [Inject]
    public void Construct(IGameStateManager gameStateManger)
    {
        _gameStateManager = gameStateManger;
    }
    void Update()
    {
        if (_gameStateManager.CurrentState != GameState.Option && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
