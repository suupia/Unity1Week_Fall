using System;
using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using Projects.Utility;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable
namespace Projects.Fruit.Scripts
{
    /// <summary>
    /// プレハブからSpriteを取得するときもこれを使用する
    /// </summary>
    public enum FruitType
    {
        Apple,
        Banana,
        Orange,
        Peach,
        Strawberry,
        Watermelon,
    }
    public class FruitCreator
    {
        readonly IPrefabLoader<Sprite> _spriteLoader;
        readonly IPrefabLoader<FruitController> _fruitLoader;
        public FruitCreator(IPrefabLoader<FruitController> fruitLoader, IPrefabLoader<Sprite> prefabLoader)
        {
            _fruitLoader = fruitLoader;
            _spriteLoader = prefabLoader;
        }
        public FruitController Create( FruitType fruitType)
        {
            // Spriteを読み込む
            var sprite = _spriteLoader.Load(fruitType.ToString());
            var fruitObj = _fruitLoader.Load("Fruit");
            fruitObj.GetComponent<SpriteRenderer>().sprite = sprite;
            return fruitObj;
        }
    }


}