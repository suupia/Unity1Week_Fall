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
            return fruitType switch
            {
                FruitType.Apple => new Apple(_resolver,amplify,scoreTextSpawner),
                FruitType.BadApple => new BadApple(_resolver,amplify ,scoreTextSpawner),
                _ => new Apple(_resolver,amplify ,scoreTextSpawner),
            };
        }
    }
}