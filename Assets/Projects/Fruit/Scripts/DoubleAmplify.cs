using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Score.Interfaces;
using Projects.Score.Script;
using Projects.Utility;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable
namespace Projects.Fruit.Scripts
{
    public class DoubleAmplify : IAmplify
    {
        readonly int _maxAmplifyCount = 1;
        readonly float _amplifyOffset = 0.1f;
        readonly float _amplifyForce = 1f;

        readonly FruitType _fruitType;
        readonly FruitControllerBuilder _fruitControllerBuilder;
        readonly FruitCountLimiter _fruitCountLimiter;


        int _currentAmplifyCount;

        public DoubleAmplify(FruitType fruitType, FruitControllerBuilder fruitControllerBuilder,
            FruitCountLimiter fruitCountLimiter)
        {
            _fruitType = fruitType;
            _fruitControllerBuilder = fruitControllerBuilder;
            _fruitCountLimiter = fruitCountLimiter;
        }

        public void Amplify(Transform transform)
        {
            if (_currentAmplifyCount >= _maxAmplifyCount) return;
            if(_fruitCountLimiter.IsLimit) return;
            var offset = _amplifyOffset * ProjectUtility.RandomDownVector2();
            var fruitController = _fruitControllerBuilder.Build(_fruitType, transform.position + (Vector3)offset);
            var fruitRb = fruitController.GetComponent<Rigidbody2D>();
            fruitRb.velocity = fruitController.Velocity;
            fruitRb.AddForce(_amplifyForce * ProjectUtility.RandomVector2(), ForceMode2D.Impulse);
            
        }
    }
}