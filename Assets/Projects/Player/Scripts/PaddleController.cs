using System.Collections;
using System.Collections.Generic;
using Projects.Stage.Scripts;
using UnityEngine;
using Projects.GameSystem.Scripts;
using Projects.GameSystem.Interfaces;
using VContainer;
using UniRx;
using UniRx.Triggers;

namespace Projects.Player.Scripts
{
    public class PaddleController : MonoBehaviour
    {
        private float speed = 0.018f;

        [SerializeField] GameObject paddleObj; // widthを取るために必要 localScale.xで取得している

        IGameState _gameState;
        StageManager _stageManager;

        [Inject]
        public void Construct(IGameState gameState, StageManager stageManager)
        {
            _gameState = gameState;
            _stageManager = stageManager;
            
            Observable.EveryUpdate()
                .Where(_ => _gameState.CurrentState == GameState.Game)
                .Select(_ => Input.GetAxisRaw("Horizontal"))
                .Where(CanMove)
                .Subscribe(Move)
                .AddTo(this);
        }
        

        private void Move(float hInput)
        {
            transform.position += new Vector3(hInput * speed, 0);
        }

        private bool CanMove(float hInput)
        {
            if (hInput > 0 && transform.position.x >= _stageManager.StageWidth / 2.0f -
                paddleObj.transform.localScale.x / 2.0f - _stageManager.HorizontalMargin)
            {
                return false;
            }
            else if (hInput < 0 && transform.position.x <= -(_stageManager.StageWidth / 2.0f -
                                                             paddleObj.transform.localScale.x / 2.0f -
                                                             _stageManager.HorizontalMargin))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}