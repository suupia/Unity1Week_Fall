using System;
using System.Collections;
using System.Collections.Generic;
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
        readonly IObjectResolver _resolver;
        readonly StageManager _stageManager;
        readonly FruitControllerBuilder _fruitControllerBuilder;
        
        readonly float _spawnIntervalSeconds = 1.0f;
        
        IDisposable _spawnSubscription;
        
        [Inject]
        public FruitSpawner(IObjectResolver resolver, StageManager stageManager,FruitControllerBuilder fruitControllerBuilder)
        {
            _resolver = resolver;
            _stageManager = stageManager;
            _fruitControllerBuilder = fruitControllerBuilder;
        }
        public void Dispose()
        {
            _spawnSubscription.Dispose();
        }

        public void StartSpawn()
        {
            _spawnSubscription = Observable.EveryUpdate()
                .ThrottleFirst(TimeSpan.FromSeconds(_spawnIntervalSeconds))
                .Subscribe(_ => Spawn());
        }
        void Spawn()
        {
            var randomType = RandomType();
            var randomPosition = RandomPosition();
            _fruitControllerBuilder.Build(RandomType(), RandomPosition());
        }
        FruitType RandomType()
        {
            var random = UnityEngine.Random.Range(0, 1.0f);
            var type = random > 0.3f ? FruitType.Apple : FruitType.BadApple;
            return type;
        }

        Vector3 RandomPosition()
        {
            var random = UnityEngine.Random.Range(0, 1.0f);
            var sign = random > 0 ? 1 : -1;
            var randomX = sign * random * _stageManager.StageWidth / 2;
            var height = 4.5f;
            return new Vector3(randomX, height, 0);
        }
        
    }

}
