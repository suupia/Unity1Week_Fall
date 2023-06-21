using System;
using System.Collections;
using System.Collections.Generic;
using Projects.Stage.Scripts;
using UnityEngine;
using Projects.GameSystem.Scripts;
using Projects.GameSystem.Interfaces;
using VContainer;
using UniRx;
using UniRx.Triggers;
using Projects.Fruit.Scripts;

namespace Projects.Player.Scripts
{
    public class PaddleController : MonoBehaviour
    {
        float speed = 20f;
        float forceAmount = 30f;

        [SerializeField] GameObject paddleObj; // widthを取るために必要 localScale.xで取得している

        IGameStateManager _gameStateManager;
        StageManager _stageManager;

        // Constructでインジェクトできるのは、最初からシーン上にあるため
        [Inject]
        public void Construct(IGameStateManager gameStateManager, StageManager stageManager)
        {
            _gameStateManager = gameStateManager;
            _stageManager = stageManager;
            
            Observable.EveryUpdate()
                .Where(_ => _gameStateManager.CurrentState == GameState.Game)
                .Select(_ => Input.GetAxisRaw("Horizontal"))
                .Where(CanMove)
                .Subscribe(Move)
                .AddTo(this);
        }

        void Move(float hInput)
        {
           //  transform.position += new Vector3(hInput * speed, 0);
           var translation = new Vector3(hInput * speed, 0, 0);
           transform.Translate(translation * Time.deltaTime);
        }
        bool CanMove(float hInput)
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<FruitController>() is { } fruitController)
            {
                // BounceOff(fruitController);
                fruitController.Fruit.OnEnterBasket(fruitController.gameObject);
            }
        }

        void BounceOff(FruitController fruitController)
        {
            Debug.Log("Fruitを飛ばします");
            var rb = fruitController.GetComponent<Rigidbody2D>();
            rb.AddForce(forceAmount * Vector2.up, ForceMode2D.Impulse);
        }
    }
}