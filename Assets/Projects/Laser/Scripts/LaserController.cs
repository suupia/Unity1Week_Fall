using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Scripts;
using UnityEngine;
using VContainer;

public class LaserController : MonoBehaviour
{
    [Inject]
    public void Construct()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ToDo: とりあえず触れたら確定で2倍になる
        if (other.GetComponent<FruitController>() is { } fruitController) fruitController.Fruit.Amplify(fruitController.transform);
    }
}
