using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projects.Fruit.Interfaces
{
    public interface IFruit: IAmplifiable
    {
        void OnEnterBasket(GameObject gameObject);
    }

}
