using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Scripts;
using Projects.Stage.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects.Ground.Scripts
{
    // AutoInjectする
    public class BasketController : MonoBehaviour
    {
        [Inject]
        public void Construct()
        {
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<FruitController>() is { } fruitController) fruitController.Fruit.OnEnterBasket();
        }
    }
}