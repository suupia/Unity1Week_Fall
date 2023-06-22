using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Scripts;
using Projects.Stage.Scripts;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;
using DG.Tweening;
using Projects.SE.Scripts;

public class LaserController : MonoBehaviour
{
    StageManager _stageManager;
    [SerializeField] GameObject beamBody; // 発射時にビームの幅を調整する
    readonly float _halfDuration = 0.08f;
    float _maxThickness;

    SEController _seController;
    
    [Inject]
    public void Construct(StageManager stageManager, SEController seController)
    {
        _stageManager = stageManager;
        _seController = seController;
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_=> FireLaser())
            .AddTo(this);
        
        _maxThickness = beamBody.transform.localScale.y;
        beamBody.transform.localScale = new Vector3(1, 0, 1);
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
        
        // SEを再生
        _seController.PlayFireLaserSE();


        // Raycast
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, range);
        // Raycastの情報を可視化
        foreach (var hit in hits)
        {
            Debug.DrawRay(position, direction * hit.distance, Color.red,3);
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
        }
        
        // DoTweenで大きさを変更
        DOTween.Sequence()
            .OnStart(() => beamBody.transform.localScale = new Vector3(1, 0, 1))
            .Append(beamBody.transform.DOScaleY(_maxThickness, _halfDuration).SetEase(Ease.InCubic))
            .Append(beamBody.transform.DOScaleY(0, _halfDuration).SetEase(Ease.OutCubic))
            .Play();

        // Loop over every object that the raycast hit
        foreach (var hit in hits)
        {
            // If the hit object has a FruitController, call Amplify on it
            if (hit.collider.GetComponent<FruitController>() is { } fruitController)
                fruitController.Fruit.Amplify(fruitController.transform);
        }
 
    }

}
