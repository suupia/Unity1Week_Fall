using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Score.Interfaces;
using Projects.Score.Script;
using Projects.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;
# nullable enable
namespace Projects.Fruit.Scripts
{
    public class BadApple : IFruit
    {
        readonly IFruitScore _fruitScore;
        readonly IAmplify _amplify;
        readonly ScoreTextSpawner _scoreTextSpawner;

        readonly int _scoreAmount = 10;
        [Inject]
        public  BadApple(IObjectResolver resolver, IAmplify amplify , ScoreTextSpawner scoreTextSpawner)
        {
            _fruitScore = resolver.Resolve<IFruitScore>();
            _amplify = amplify;
            _scoreTextSpawner = scoreTextSpawner;
        }
        public void OnEnterBasket(GameObject gameObject)
        {
            Debug.Log($"BadAppleを取得");
            _fruitScore.DecreaseScore(_scoreAmount);
            UnityEngine.Object.Destroy(gameObject);
            var text = $"-{_scoreAmount}";
            _scoreTextSpawner.Spawn(FruitScoreType.Negative, text, gameObject.transform.position);
        }
        
        // ドメインスクリプトがMonoの要素に依存しているのはよくないかもと思ったので、Transformは引数で受け取るようにした
        public void Amplify(Transform transform)
        {
            Debug.Log($"BadAppleが増加しました");
            _amplify.Amplify(transform);
        }
    }
}