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
    public enum FruitScoreSign
    {
        Positive,
        Negative
    }

    public record FruitRecord
    {
        public readonly FruitType fruitType;
        public readonly FruitScoreSign fruitScoreSign;
        public readonly double scoreAmount;
        public int generationCount;

        public FruitRecord(FruitType fruitType,FruitScoreSign fruitScoreSign, double scoreAmount)
        {
            this.fruitType = fruitType;
            this.fruitScoreSign = fruitScoreSign;
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
            var fruitScoreType =_fruitRecord.fruitScoreSign;
            switch (fruitScoreType)
            {
                case FruitScoreSign.Positive:
                    _fruitScore.IncreaseScore(_fruitRecord.scoreAmount);
                    break;
                case FruitScoreSign.Negative:
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

        string DetermineScoreText(FruitScoreSign fruitScoreSign, double amount)
        {
            return fruitScoreSign switch
            {
                FruitScoreSign.Positive => $"+{amount}",
                FruitScoreSign.Negative => $"-{amount}",
                _ => throw new ArgumentOutOfRangeException(nameof(fruitScoreSign), fruitScoreSign, null)
            };
        }

    }
}