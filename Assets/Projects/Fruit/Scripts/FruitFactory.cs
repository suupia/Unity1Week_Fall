using System;
using Projects.Fruit.Interfaces;
using Projects.Score.Script;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace Projects.Fruit.Scripts
{
    public class FruitFactory
    {
        readonly IObjectResolver _resolver;
        [Inject]
        public FruitFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        public IFruit  CreateFruit(FruitType fruitType,FruitScoreSign fruitScoreSign, int generateCount)
        {
            var fruitBuilder = _resolver.Resolve<FruitControllerBuilder>();
            var fruitCountLimiter = _resolver.Resolve<FruitCountLimiter>();
            var amplify = new DoubleAmplify(fruitBuilder, fruitCountLimiter,fruitType,fruitScoreSign, generateCount); // とりあえずすべて共通なのでswitchの外に書ける
            var scoreTextSpawner = _resolver.Resolve<ScoreTextSpawner>();
            return new Fruit(_resolver,amplify,scoreTextSpawner,DetermineFruitRecord(fruitType, fruitScoreSign));
        }

        FruitRecord DetermineFruitRecord(FruitType fruitType, FruitScoreSign fruitScoreSign)
        {
            double scoreAmount = fruitType switch
            {
                FruitType.Apple => 10,
                FruitType.Cherries => 30,
                FruitType.Strawberry => 100,
                FruitType.Melon => 270,
                FruitType.Pineapple => 1000,
                FruitType.Orange => 3800,
                FruitType.Bananas => 17000,
                FruitType.Kiwi => 77000,
                _ => throw new ArgumentOutOfRangeException(nameof(fruitType), fruitType, null)
            };
            return new FruitRecord(fruitType, fruitScoreSign, scoreAmount);
        }
    }
}