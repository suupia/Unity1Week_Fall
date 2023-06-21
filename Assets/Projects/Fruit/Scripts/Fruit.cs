using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.GameSystem.Interfaces;
using Projects.Score.Interfaces;
using Projects.Score.Script;
using Projects.Utility;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

# nullable enable
namespace Projects.Fruit.Scripts
{
    public enum FruitScoreType
    {
        Positive,
        Negative
    }

    public record FruitRecord
    {
        public readonly FruitType fruitType;
        public readonly double scoreAmount;
        public int generationCount;

        public FruitRecord(FruitType fruitType, double scoreAmount)
        {
            this.fruitType = fruitType;
            this.scoreAmount = scoreAmount;
        }
    }

    public class Fruit : IFruit
    {
        readonly IFruitScore _fruitScore;
        readonly IAmplify _amplify;
        readonly ScoreTextSpawner _scoreTextSpawner;
        readonly FruitRecord _fruitRecord;


        [Inject]
        public Fruit(IObjectResolver resolver, IAmplify amplify, ScoreTextSpawner scoreTextSpawner,
            FruitRecord fruitRecord)
        {
            _fruitScore = resolver.Resolve<IFruitScore>();
            _amplify = amplify;
            _scoreTextSpawner = scoreTextSpawner;
            _fruitRecord = fruitRecord;
        }

        public void OnEnterBasket(GameObject gameObject)
        {
            var fruitType = _fruitRecord.fruitType;
            Debug.Log($"fruitType:{fruitType}を取得");
            var fruitScoreType = DetermineFruitScoreType(fruitType);
            switch (fruitScoreType)
            {
                case FruitScoreType.Positive:
                    _fruitScore.IncreaseScore(_fruitRecord.scoreAmount);
                    break;
                case FruitScoreType.Negative:
                    _fruitScore.DecreaseScore(_fruitRecord.scoreAmount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fruitScoreType), fruitScoreType, null);
                    break;
            }
            var text = DetermineScoreText(fruitScoreType, _fruitRecord.scoreAmount);
            _scoreTextSpawner.Spawn(fruitScoreType, text,
                gameObject.transform.position);
            UnityEngine.Object.Destroy(gameObject);
        }

        public void Amplify(Transform transform)
        {
            Debug.Log($"fruitType:{_fruitRecord.fruitType}を増幅");
            _amplify.Amplify(transform);
        }

        string DetermineScoreText(FruitScoreType fruitScoreType, double amount)
        {
            return fruitScoreType switch
            {
                FruitScoreType.Positive => $"+{amount}",
                FruitScoreType.Negative => $"-{amount}",
                _ => throw new ArgumentOutOfRangeException(nameof(fruitScoreType), fruitScoreType, null)
            };
        }

        FruitScoreType DetermineFruitScoreType(FruitType fruitType)
        {
            return fruitType switch
            {
                FruitType.Apple or FruitType.Bananas or FruitType.Cherries or FruitType.Kiwi or FruitType.Melon
                    or FruitType.Orange or FruitType.Pineapple or FruitType.Strawberry
                    => FruitScoreType.Positive,
                FruitType.BadApple or FruitType.BadBananas or FruitType.BadCherries or FruitType.BadKiwi
                    or FruitType.BadMelon
                    or FruitType.BadOrange or FruitType.BadPineapple or FruitType.BadStrawberry
                    => FruitScoreType.Negative,
                _ => throw new ArgumentOutOfRangeException(nameof(fruitType), fruitType, null)
            };
        }
    }
}