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
            return fruitType switch
            {
                FruitType.Apple => new Apple(_resolver),
                FruitType.BadApple => new BadApple(_resolver),
                _ => new Apple(_resolver),
            };
        }
    }
}