using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Level.Interfaces;
using Projects.Score.Script;
using Projects.SE.Scripts;
using UniRx;
using UnityEngine;
using VContainer;

public class LevelUpTextController : MonoBehaviour
{
    readonly float _offset = 8; // 画面外から出てくる位置
    readonly float _moveDuration = 1.2f; // AttackとReleaseのそれぞれの時間
    readonly float _showDuration = 0.05f; // holdの時間

    SEController _seController;
    
    [Inject]
    public void Construct(ILevelManager levelManager, SEController seController)
    {
        _seController = seController;
        
        levelManager.ObserveEveryValueChanged(x => x.CurrentLevel)
            .Where(_ => levelManager.CurrentLevel > 0)
            .Subscribe(_ => ShowLevelUpText());
    }

    void ShowLevelUpText()
    {
        var startPos = new Vector3(0.0f, -_offset, 0.0f);
        var centerPos = new Vector3(0.0f, 0.0f, 0.0f);
        var endPos = new Vector3(0.0f, _offset, 0.0f);
        
        _seController.PlayLevelUpSE(); // 明らかにここにあるのはクラス名と違ってまずいｗ
        
        DOTween.Sequence()
            .OnStart(() => { transform.position = startPos; })
            .Append(transform.DOMove(centerPos, _moveDuration / 2).SetEase(Ease.OutQuart))
            .AppendInterval(_showDuration)
            .Append(transform.DOMove(endPos, _moveDuration / 2).SetEase(Ease.InQuart))
            .Play();
    }
}