using System;
using System.Collections;
using System.Collections.Generic;
using Level.Interfaces;
using Projects.Stage.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UniRx;
using UniRx.Triggers;
using Object = UnityEngine.Object;
using Random = Unity.Mathematics.Random;
#nullable enable
namespace Projects.Fruit.Scripts
{
    public class FruitTypeSelector
    {
        readonly ILevelManager _levelManager;
        public FruitTypeSelector(ILevelManager levelManager)
        {
            _levelManager = levelManager;
        } 
        
        // public FruitType Select()
        // {
        //     var random = UnityEngine.Random.Range(0, 1.0f);
        //     return _levelManager.CurrentLevel switch
        //     {
        //         0 => LevelZero(random),
        //         1 => LevelOne(random),
        //     };
        // }
        //
        // FruitType LevelZero(float random)
        // {
        //     return random > 0.3f ? FruitType.Apple : FruitType.BadApple;
        // }
        //
        // FruitType LevelOne(float random)
        // {
        //     return random > 0.5f ? FruitType.Apple : FruitType.BadApple;
        // }
    }
}