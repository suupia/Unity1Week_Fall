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

namespace Projects.Fruit.Scripts
{
    // AutoInjectする
    // ステージ状にランダムにフルーツを生成する
    public class FruitSpawner : IDisposable 
    {
        readonly IObjectResolver _resolver;
        readonly StageManager _stageManager;
        readonly FruitCreator _fruitCreator;
        
        readonly float _spawnIntervalSeconds = 1.0f;
        
        IDisposable _spawnSubscription;
        
        [Inject]
        public FruitSpawner(IObjectResolver resolver, StageManager stageManager,FruitCreator fruitCreator)
        {
            _resolver = resolver;
            _stageManager = stageManager;
            _fruitCreator = fruitCreator;
        }
        // Resourceフォルダからフルーツプレハブを読み込む
    
        // 読み込んだフルーツ対してドメインスクリプトを付与する
        
        public void Dispose()
        {
            _spawnSubscription.Dispose();
        }

        public void StartSpawn()
        {
            Observable.EveryUpdate()
                .ThrottleFirst(TimeSpan.FromSeconds(_spawnIntervalSeconds))
                .Subscribe(_ => Spawn());
        }

        Vector3 RandomPosition()
        {
            // ToDo: 実装
            return new Vector3(0, 3.5f, 0);
        }
        void Spawn()
        {
            var randomPosition = RandomPosition();
            var fruitObj = _fruitCreator.Create(FruitType.Apple);
            _resolver.Instantiate(fruitObj,randomPosition,Quaternion.identity);
        }
    }

}
