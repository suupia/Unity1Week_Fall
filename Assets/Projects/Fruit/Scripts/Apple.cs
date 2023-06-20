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
    public class Apple : IFruit
    {
        readonly IObjectResolver _resolver;
        readonly FruitCreator _fruitCreator;
        readonly IFruitScore _fruitScore;
        
        readonly int _scoreAmount = 10;
        [Inject]
        public  Apple(IObjectResolver resolver)
        {
            _resolver = resolver;
            _fruitCreator = resolver.Resolve<FruitCreator>();
            _fruitScore = resolver.Resolve<IFruitScore>();

        }
        public void OnEnterBasket()
        {
            Debug.Log($"Appleを取得");
            _fruitScore.IncreaseScore(_scoreAmount);
        }
        
        // ドメインスクリプトがMonoの要素に依存しているのはよくないかもと思ったので、Transformは引数で受け取るようにした
        public void Amplify(Transform transform)
        {
            Debug.Log($"Appleが増加しました");
            var fruitObj = _fruitCreator.Create(FruitType.Apple);
            _resolver.Instantiate(fruitObj,transform.position,Quaternion.identity);
        }
    }
}