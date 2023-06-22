using System;
using System.Collections;
using System.Collections.Generic;
using Projects.BGM.Scripts;
using Projects.Fruit.Interfaces;
using Projects.Fruit.Scripts;
using Projects.GameSystem.Interfaces;
using Projects.Ground.Scripts;
using Projects.Timer.Scripts;
using Projects.Utility;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects.GameSystem.Scripts
{
    // AutoInjectする
    public class GameInitializer : MonoBehaviour
    {
        [Inject] IGameStateManager _gameStateManagerManager;
        [Inject] FruitSpawner _fruitSpawner;
        [Inject] LaserSpawner _laserSpawner;
        [Inject] StageTimer _stageTimer;
        [Inject] BGMController _bgmController;
        void Start()
        {
            _gameStateManagerManager.ChangeState(GameState.Game);
            _fruitSpawner.StartSpawn();
            _laserSpawner.StartSpawn();
            _stageTimer.StartTimer();
            _bgmController.PlayBGM();
        }
    }
}