using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Scripts;
using Projects.Stage.Scripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

public class LaserController : MonoBehaviour
{
    StageManager _stageManager;
    [Inject]
    public void Construct(StageManager stageManager)
    {
        _stageManager = stageManager;
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_=> FireLaser())
            .AddTo(this);
    }
    
    
    void FireLaser()
    {
        // Laser's direction (upwards in this case)
        Vector2 direction = Vector2.right;

        // Laser's range
        float range = _stageManager.StageWidth;
        
        // オブジェクトの真ん中が射程の中心になるように左からRayを飛ばす
        var positionX = transform.position.x - range /2.0f;
        var position = new Vector2(positionX, transform.position.y);

        // Raycast
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, range);
    
        // Loop over every object that the raycast hit
        foreach (var hit in hits)
        {
            // If the hit object has a FruitController, call Amplify on it
            if (hit.collider.GetComponent<FruitController>() is { } fruitController)
                fruitController.Fruit.Amplify(fruitController.transform);
        }
 
    }

}
