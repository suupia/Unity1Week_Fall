using System;
using Projects.Fruit.Scripts;
using Projects.Stage.Scripts;
using UniRx;
using UnityEngine;
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
            for (int i = 0; i < 3; i++)
            {
                var spawnPosition = new Vector2(0, i * 2);
                var laserObj = _laserCreator.Create();
                _resolver.Instantiate(laserObj,spawnPosition,Quaternion.identity);
            }
        }
    }
}