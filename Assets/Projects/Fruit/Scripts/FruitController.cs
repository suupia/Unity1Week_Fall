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
    [RequireComponent(typeof(Rigidbody2D))]
    public class FruitController : MonoBehaviour
    {
        public IFruit Fruit => _fruit;
        public Vector2 Velocity => _rb.velocity;


        readonly float _bottomDestroyLine = -10f;
        readonly float _topDestroyLine = 7f;

        IFruit _fruit;
        Rigidbody2D _rb;

        public void Init(IFruit fruit)
        {
            _fruit = fruit;

            _rb = gameObject.GetComponent<Rigidbody2D>();

            // 低すぎる場所に行くとDestroyする
            this.UpdateAsObservable()
                .Where(_ => transform.position.y <= _bottomDestroyLine)
                .Subscribe(_ => Destroy(gameObject));

            // 高すぎる場所に行くとDestroyする
            this.UpdateAsObservable()
                .Where(_ => transform.position.y >= _topDestroyLine)
                .Subscribe(_ => Destroy(gameObject));
        }
    }
}