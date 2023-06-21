using Projects.Fruit.Scripts;
using  Projects. Score.Interfaces;
using Projects.Utility;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

#nullable  enable
namespace Projects.Score.Script
{
    public class ScoreTextSpawner
    {
        readonly PrefabLoaderFromResources<FruitScoreTextController> _prefabLoader;


        public ScoreTextSpawner()
        {
            _prefabLoader = new PrefabLoaderFromResources<FruitScoreTextController>("Prefabs/Score");
        }
        
        public void Spawn(FruitScoreType scoreType, string text,Vector3 position)
        {
            var textPrefab = _prefabLoader.Load("FruitScoreText");
            var textController = Object.Instantiate(textPrefab, position, quaternion.identity);
            textController.Init(scoreType, text);
        }
    }
}