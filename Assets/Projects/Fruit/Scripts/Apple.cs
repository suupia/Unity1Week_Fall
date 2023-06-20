using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Score.Interfaces;
using Projects.Score.Script;
using Projects.Utility;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;
# nullable enable
namespace Projects.Fruit.Scripts
{
    public class Apple : IFruit
    {
        readonly IObjectResolver _resolver;
        readonly FruitControllerLoader _fruitControllerLoader;
        readonly IFruitScore _fruitScore;
        
        readonly float _amplifyOffset = 0.1f;
        readonly float _amplifyForce = 1f; 
        
        readonly int _scoreAmount = 10;
        [Inject]
        public  Apple(IObjectResolver resolver)
        {
            _resolver = resolver;
            _fruitControllerLoader = resolver.Resolve<FruitControllerLoader>();
            _fruitScore = resolver.Resolve<IFruitScore>();

        }
        public void OnEnterBasket(GameObject gameObject)
        {
            Debug.Log($"Appleを取得");
            _fruitScore.IncreaseScore(_scoreAmount);
            UnityEngine.Object.Destroy(gameObject);
        }
        
        // ドメインスクリプトがMonoの要素に依存しているのはよくないかもと思ったので、Transformは引数で受け取るようにした
        public void Amplify(Transform transform)
        {
            Debug.Log($"Appleが増加しました");
            var fruitBuilder = _resolver.Resolve<FruitControllerBuilder>();
            var offset = _amplifyOffset * ProjectUtility.RandomDownVector2();
            var fruitController =  fruitBuilder.Build(FruitType.Apple,transform.position + (Vector3)offset);
            var fruitRb = fruitController.GetComponent<Rigidbody2D>();
            fruitRb.velocity = fruitController.Velocity;
            fruitRb.AddForce(_amplifyForce * ProjectUtility.RandomVector2(), ForceMode2D.Impulse);
        }
        

    }
}