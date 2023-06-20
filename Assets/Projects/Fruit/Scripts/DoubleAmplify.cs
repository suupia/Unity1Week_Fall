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
        readonly float _amplifyOffset = 0.3f;
        readonly float _amplifyForce = 1f;

        readonly FruitControllerBuilder _fruitControllerBuilder;
        readonly FruitCountLimiter _fruitCountLimiter;
        readonly FruitType _fruitType;

        int _currentAmplifyCount;
        readonly int _maxGenerationCount = 3;
        int _generationCount; // 世代数 ものすごく増えてしまうことを避ける

        public DoubleAmplify(FruitControllerBuilder fruitControllerBuilder,
            FruitCountLimiter fruitCountLimiter,FruitType fruitType, int generationCount)
        {
            _fruitControllerBuilder = fruitControllerBuilder;
            _fruitCountLimiter = fruitCountLimiter;
            _fruitType = fruitType;
            _generationCount = generationCount;
            Debug.Log($"generationCount = {_generationCount}");
        }

        public void Amplify(Transform transform)
        {
            if(!CanAmplify())return;
            var offset = _amplifyOffset * ProjectUtility.RandomDownVector2();
            var fruitController = _fruitControllerBuilder.Build(_fruitType, transform.position + (Vector3)offset, _generationCount + 1);
            var fruitRb = fruitController.GetComponent<Rigidbody2D>();
            fruitRb.velocity = fruitController.Velocity;
            fruitRb.AddForce(_amplifyForce * ProjectUtility.RandomVector2(), ForceMode2D.Impulse);
            
        }

        bool CanAmplify()
        {
            if (_currentAmplifyCount >= _maxAmplifyCount) return false;
            if(_fruitCountLimiter.IsLimit) return false;
            if(_generationCount >= _maxGenerationCount) return false;
            return true;
        }
    }
}