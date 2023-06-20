using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Utility;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects.Fruit.Scripts
{
    public class FruitController: MonoBehaviour
    {
        public IFruit Fruit => _fruit;
        
        IFruit _fruit;
        
        [Inject]
        public void Construct(IFruit fruit)
        {
            _fruit = fruit;
        }
        
    }
}