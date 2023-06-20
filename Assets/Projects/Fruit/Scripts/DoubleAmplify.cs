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
#nullable enable
namespace Projects.Fruit.Scripts
{
    public class DoubleAmplify : IAmplify
    {
        readonly int _maxAmplifyCount = 2;
        readonly float _amplifyOffset = 0.1f;
        readonly float _amplifyForce = 1f; 
        
        readonly FruitControllerBuilder _fruitControllerBuilder;
        
       readonly   FruitType _fruitType;

       int _currentAmplifyCount;
         
        public DoubleAmplify( FruitType fruitType, FruitControllerBuilder fruitControllerBuilder)
        {
            _fruitType = fruitType;

            _fruitControllerBuilder = fruitControllerBuilder;
        }
        public void Amplify(Transform transform)
        {
            if(_currentAmplifyCount >= _maxAmplifyCount) return;
            var offset = _amplifyOffset * ProjectUtility.RandomDownVector2();
            var fruitController =  _fruitControllerBuilder.Build(_fruitType,transform.position + (Vector3)offset);
            var fruitRb = fruitController.GetComponent<Rigidbody2D>();
            fruitRb.velocity = fruitController.Velocity;
            fruitRb.AddForce(_amplifyForce * ProjectUtility.RandomVector2(), ForceMode2D.Impulse);
            
            _currentAmplifyCount++;
        }
    }
}