using System;
using Projects.Fruit.Scripts;
using Projects.Stage.Scripts;
using UniRx;
using UnityEngine;
using UnityEngine.Analytics;
using VContainer;
using VContainer.Unity;

namespace Projects.Ground.Scripts
{
    public class LaserSpawner 
    {
        readonly IObjectResolver _resolver;
        readonly StageManager _stageManager;
        readonly LaserCreator _laserCreator;
        
        readonly float _spawnIntervalSeconds = 1.0f;
        
        IDisposable _spawnSubscription;
        
        [Inject]
        public LaserSpawner(IObjectResolver resolver, StageManager stageManager,LaserCreator laserCreator)
        {
            _resolver = resolver;
            _stageManager = stageManager;
            _laserCreator = laserCreator;
        }
        

        public void StartSpawn()
        {
            Spawn();
        }
        
        void Spawn()
        {
            // ToDo : 高さを正確に決める
            float initHeight = -0.3f;
            float interval = 2.0f;
            int laserCount = 2;
            for (int i = 0; i < laserCount; i++)
            {
                var spawnPosition = new Vector2(0, initHeight + i * interval);
                var laserObj = _laserCreator.Create();
                _resolver.Instantiate(laserObj,spawnPosition,Quaternion.identity);
            }
        }
    }
}