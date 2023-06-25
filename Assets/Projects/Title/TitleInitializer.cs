using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Projects.GameSystem.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class TitleInitializer : MonoBehaviour
{
    IGameStateManager _gameStateManager;
    [SerializeField] GameObject titleParent;
    [SerializeField] GameObject optionExplanationParent;
    
    bool _isOptionExplanationShowed = false;
    readonly float _optionExplanationShowTimeMin = 0.5f;
    
    [Inject]
    public void Construct(IGameStateManager gameStateManger)
    {
        _gameStateManager = gameStateManger;
    }
    void Update()
    {
        if (_gameStateManager.CurrentState != GameState.Option && Input.anyKey)
        {
            if (_isOptionExplanationShowed)
            {
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                ShowOptionExplanation();
            }
        }
        
    }
    
    async void ShowOptionExplanation()
    {
        titleParent.SetActive(false);
        optionExplanationParent.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(_optionExplanationShowTimeMin));
        _isOptionExplanationShowed = true;
    }
}
