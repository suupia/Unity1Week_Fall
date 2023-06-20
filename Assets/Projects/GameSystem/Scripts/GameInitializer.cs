using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.Fruit.Scripts;
using Projects.GameSystem.Interfaces;
using Projects.Utility;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects.GameSystem.Scripts
{
    // AutoInjectする
    public class GameInitializer : MonoBehaviour
    {
        [Inject] FruitSpawner _fruitSpawner;
        void Start()
        {
            _fruitSpawner.StartSpawn();
        }
    }
}