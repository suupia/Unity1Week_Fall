using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public FruitType SelectFruitType(long currentLevel)
        {
            var random = UnityEngine.Random.Range(0, 1.0f);
            return currentLevel switch
            {
                0 => RandomFruitType((FruitType.Apple, 100)),
                
                1 => RandomFruitType((FruitType.Apple, 70), (FruitType.Bananas, 30)),
                
                2 => RandomFruitType((FruitType.Apple, 50), (FruitType.Bananas, 40), (FruitType.Cherries, 10)),
                
                3 => RandomFruitType((FruitType.Apple, 30), (FruitType.Bananas, 30), (FruitType.Cherries, 20),
                    (FruitType.Kiwi, 20)),
                
                4 => RandomFruitType((FruitType.Apple, 20), (FruitType.Bananas, 20), (FruitType.Cherries, 20),
                    (FruitType.Kiwi, 20), (FruitType.Melon, 20)),
                
                5 => RandomFruitType((FruitType.Apple, 15), (FruitType.Bananas, 15), (FruitType.Cherries, 15),
                    (FruitType.Kiwi, 15), (FruitType.Melon, 20), (FruitType.Orange, 20)),
                
                6 => RandomFruitType((FruitType.Apple, 10), (FruitType.Bananas, 10), (FruitType.Cherries, 10),
                    (FruitType.Kiwi, 10), (FruitType.Melon, 10), (FruitType.Orange, 20), (FruitType.Pineapple, 30)),
                
                _ => RandomFruitType((FruitType.Apple, 5), (FruitType.Bananas, 5), (FruitType.Cherries, 10),
                    (FruitType.Kiwi, 10), (FruitType.Melon, 10), (FruitType.Orange, 20), (FruitType.Pineapple, 20),
                    (FruitType.Strawberry, 20)),
            };
        }

        public FruitScoreSign SelectFruitScoreSign(long currentLevel)
        {
            var random = UnityEngine.Random.Range(0, 1.0f);
            return   random > 0.3f ? FruitScoreSign.Positive :FruitScoreSign.Negative;
            // return _levelManager.CurrentLevel switch
            // {
            //     0 => LevelZeroSign(random),
            //     1 => LevelOneSign(random),
            // };
        }

        FruitType RandomFruitType(params (FruitType, float)[] fruitPairs)
        {
            // 合計を計算する
            var total = fruitPairs.Sum(pair => pair.Item2);

            var random = UnityEngine.Random.Range(0, total);
            var sum = 0.0f;
            foreach (var (fruitType, rate) in fruitPairs)
            {
                sum += rate;
                if (random < sum)
                {
                    return fruitType;
                }
            }

            return fruitPairs[^1].Item1; // ^1は配列の最後の要素を指す
        }
    }
}