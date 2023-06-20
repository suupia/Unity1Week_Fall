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
        readonly IObjectResolver _resolver;
        readonly FruitControllerLoader _fruitControllerLoader;
        readonly IFruitScore _fruitScore;
        
        readonly int _scoreAmount = 10;
        [Inject]
        public  BadApple(IObjectResolver resolver)
        {
            _resolver = resolver;
            _fruitControllerLoader = resolver.Resolve<FruitControllerLoader>();
            _fruitScore = resolver.Resolve<IFruitScore>();

        }
        public void OnEnterBasket(GameObject gameObject)
        {
            Debug.Log($"BadAppleを取得");
            _fruitScore.DecreaseScore(_scoreAmount);
            UnityEngine.Object.Destroy(gameObject);
        }
        
        // ドメインスクリプトがMonoの要素に依存しているのはよくないかもと思ったので、Transformは引数で受け取るようにした
        public void Amplify(Transform transform)
        {
            Debug.Log($"BadAppleが増加しました");
            var fruitBuilder = _resolver.Resolve<FruitControllerBuilder>();
            fruitBuilder.Build(FruitType.BadApple,transform.position);
        }
    }
}