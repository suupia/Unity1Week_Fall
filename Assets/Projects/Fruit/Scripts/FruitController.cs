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
using UniRx;
using UniRx.Triggers;

namespace Projects.Fruit.Scripts
{
    public class FruitController: MonoBehaviour
    {
        public IFruit Fruit => _fruit;
        
       readonly  float _destroyHeight = -10f;
        
        IFruit _fruit;
        
        public void Init(IFruit fruit)
        {
            _fruit = fruit;
            this.UpdateAsObservable()
                .Where(_ => transform.position.y <= _destroyHeight)
                .Subscribe(_ => Destroy(gameObject));
        }

    }
}