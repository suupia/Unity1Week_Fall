using System;
using System.Collections;
using System.Collections.Generic;
using Level.Interfaces;
using Projects.Stage.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UniRx;
using UniRx.Triggers;
using Object = UnityEngine.Object;
using Random = Unity.Mathematics.Random;

# nullable enable
namespace Projects.Fruit.Scripts
{
    /// <summary>
    /// ステージ状にランダムにフルーツを生成する
    /// </summary>
    public class FruitSpawner : IDisposable
    {
        readonly StageManager _stageManager;
        readonly FruitControllerBuilder _fruitControllerBuilder;
        readonly ILevelManager _levelManager;
        readonly FruitTypeSelector _fruitTypeSelector;

        readonly float _initSpawnIntervalSeconds = 1.0f;

        IDisposable? _spawnSubscription;

        [Inject]
        public FruitSpawner(StageManager stageManager,
            FruitControllerBuilder fruitControllerBuilder, ILevelManager levelManager, FruitTypeSelector fruitTypeSelector)
        {
            _stageManager = stageManager;
            _fruitControllerBuilder = fruitControllerBuilder;
            _levelManager = levelManager;
            _fruitTypeSelector = fruitTypeSelector;
        }

        public void Dispose()
        {
            _spawnSubscription?.Dispose();
        }

        public void StartSpawn()
        {
            _spawnSubscription = Observable.Interval(TimeSpan.FromSeconds(CalculateSpawnIntervalSeconds()))
                .Subscribe(_ => Spawn());

            _levelManager.ObserveEveryValueChanged(x => x.CurrentLevel)
                .Subscribe(_ =>
                {
                    _spawnSubscription.Dispose();
                    _spawnSubscription = Observable.Interval(TimeSpan.FromSeconds(CalculateSpawnIntervalSeconds()))
                        .Subscribe(_ => Spawn());
                });
        }

        void Spawn()
        {
            var randomType = _fruitTypeSelector.SelectFruitType(_levelManager.CurrentLevel);
            var randomSign = _fruitTypeSelector.SelectFruitScoreSign(_levelManager.CurrentLevel);
            var randomPosition = RandomPosition();
            _fruitControllerBuilder.Build(randomType, randomSign, randomPosition, 0);
        }
        
        Vector3 RandomPosition()
        {
            var random = UnityEngine.Random.Range(0, 1.0f);
            var sign = random > 0.5f ? 1 : -1;
            var randomX = sign * random * _stageManager.StageWidth / 2;
            var height = 4.5f;
            return new Vector3(randomX, height, 0);
        }

        float CalculateSpawnIntervalSeconds()
        {
            var level = _levelManager.CurrentLevel;
            var rate =level != 0 ?   1 / Mathf.Pow(level, 0.25f) : 1;  // Powの値を減らすとスポーンの頻度が上がる
            var interval = _initSpawnIntervalSeconds * rate;
            return interval;
        }
    }
}