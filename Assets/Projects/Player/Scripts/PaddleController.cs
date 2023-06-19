using System.Collections;
using System.Collections.Generic;
using Projects.Stage.Scripts;
using UnityEngine;
using Projects.GameSystem.Scripts;
using Projects.GameSystem.Interfaces;
using VContainer;

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
        }

        void Update()
        {
            if (_gameState.CurrentState != GameState.Game) return;
            Move();
        }

        private void Move()
        {
            float vInput = Input.GetAxisRaw("Vertical");
            float hInput = Input.GetAxisRaw("Horizontal");

            if (hInput != 0 || vInput != 0)
            {
                //Debug.Log("移動キーが入力されました。");

                if (CanMove(hInput, vInput))
                {
                    transform.position += new Vector3(hInput * speed, vInput * speed);
                }
                else
                {
                    //Debug.Log($"GanMove({horizontalInput},{verticalInput}はfalseです)");
                    return;
                }
            }
        }

        private bool CanMove(float hInput, float vInput)
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