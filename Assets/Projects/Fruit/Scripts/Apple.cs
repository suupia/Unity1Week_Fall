using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
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
        [Inject]
        public  Apple(IObjectResolver resolver, FruitCreator fruitCreator)
        {
            _resolver = resolver;
            _fruitCreator = fruitCreator;
        }
        public void OnEnterBasket()
        {
            Debug.Log($"Appleを取得");
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