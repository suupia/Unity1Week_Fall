using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable
namespace Projects.Fruit.Scripts
{
    public class FruitCountLimiter
    {
        public bool IsLimit => _currentFruitCount >= _limitCount;

        readonly int _limitCount = 100;
        int _currentFruitCount;
        
        public void IncreaseFruitCount()
        {
            _currentFruitCount++;
        }
        public void DecreaseFruitCount()
        {
            _currentFruitCount--;
        }
    }
}