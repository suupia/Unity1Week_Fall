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
            return fruitType switch
            {
                FruitType.Apple => new Apple(_resolver,new DoubleAmplify(fruitType, fruitBuilder) ),
                FruitType.BadApple => new BadApple(_resolver,new DoubleAmplify(fruitType, fruitBuilder) ),
                _ => new Apple(_resolver,new DoubleAmplify(fruitType, fruitBuilder) ),
            };
        }
    }
}