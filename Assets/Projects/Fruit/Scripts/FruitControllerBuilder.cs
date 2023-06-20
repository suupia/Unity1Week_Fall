using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

#nullable enable
namespace Projects.Fruit.Scripts
{
    public class FruitControllerBuilder
    {
        readonly FruitControllerLoader _loader;
        readonly FruitFactory _factory;
        [Inject]
        public  FruitControllerBuilder(FruitControllerLoader loader, FruitFactory factory)
        {
            _loader = loader;
            _factory = factory;
        }

        public FruitController Build(FruitType fruitType, Vector3 position)
        {
            var fruitPrefab = _loader.LoadFruitController(fruitType);
            var fruitController = Object.Instantiate(fruitPrefab, position, Quaternion.identity);
            fruitController.Init(_factory.CreateFruit(fruitType));
            return fruitController;
        }
    }
}