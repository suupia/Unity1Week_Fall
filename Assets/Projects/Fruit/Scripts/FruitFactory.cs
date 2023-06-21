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
        public IFruit  CreateFruit(FruitType fruitType, int generateCount)
        {
            var fruitBuilder = _resolver.Resolve<FruitControllerBuilder>();
            var fruitCountLimiter = _resolver.Resolve<FruitCountLimiter>();
            var amplify = new DoubleAmplify(fruitBuilder, fruitCountLimiter,fruitType, generateCount); // とりあえずすべて共通なのでswitchの外に書ける
            var scoreTextSpawner = _resolver.Resolve<ScoreTextSpawner>();
            return new Fruit(_resolver,amplify,scoreTextSpawner,DetermineFruitRecord(fruitType));
        }

        FruitRecord DetermineFruitRecord(FruitType fruitType)
        {
            double scoreAmount = fruitType switch
            {
                FruitType.Apple => 10,
                FruitType.Bananas => 20,
                FruitType.Cherries => 30,
                FruitType.Kiwi => 40,
                FruitType.Melon => 50,
                FruitType.Orange => 60,
                FruitType.Pineapple => 70,
                FruitType.Strawberry => 80,
                FruitType.BadApple => 10,
                FruitType.BadBananas => 20,
                FruitType.BadCherries => 30,
                FruitType.BadKiwi => 40,
                FruitType.BadMelon => 50,
                FruitType.BadOrange => 60,
                FruitType.BadPineapple => 70,
                FruitType.BadStrawberry => 80,
                _ => throw new ArgumentOutOfRangeException(nameof(fruitType), fruitType, null)
            };
            return new FruitRecord(fruitType, scoreAmount);
        }
    }
}