using Projects.Fruit.Interfaces;
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
        public IFruit  CreateFruit(FruitType fruitType)
        {
            var fruitBuilder = _resolver.Resolve<FruitControllerBuilder>();
            var fruitCountLimiter = _resolver.Resolve<FruitCountLimiter>();
            var amplify = new DoubleAmplify(fruitType, fruitBuilder, fruitCountLimiter); // とりあえずすべて共通なのでswitchの外に書ける
            return fruitType switch
            {
                FruitType.Apple => new Apple(_resolver,amplify),
                FruitType.BadApple => new BadApple(_resolver,amplify ),
                _ => new Apple(_resolver,amplify ),
            };
        }
    }
}