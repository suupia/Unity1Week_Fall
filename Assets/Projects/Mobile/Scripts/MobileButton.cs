using Projects.GameSystem.Interfaces;
using Projects.Player.Scripts;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer.Unity;
using VContainer;

namespace Projects.Mobile.Scripts
{
    enum ButtonType
    {
        Left,
        Right,
        Space,
    }

    public class MobileButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] ButtonType buttonType; // インスペクター上で設定
        bool isPressed;

        BasketController _basketController;
        LaserController _laserController;
        
        IGameStateManager _gameStateManager;

        [SerializeField] Image _testImage;
        

        void Start()
        {
            if(Application.isMobilePlatform)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
            
            _testImage.color = Color.blue;


            // basketControllerをヒエラルキー上から取得する
            _basketController = GameObject.FindWithTag("Player").GetComponent<BasketController>();

            // laserControllerは動的に生成されるため、Start()で取得できない
            
            // gameStateManagerをヒエラルキー上から取得する
            _gameStateManager = GameObject.Find("LifeTimeScope").GetComponent<LifetimeScope>().Container.Resolve<IGameStateManager>();

            this.ObserveEveryValueChanged(x => x._gameStateManager.CurrentState)
                .Subscribe(x =>
                {
                    gameObject.SetActive(x == GameState.Game);
                });
        }

        　void Update()
        {
            if (isPressed)
            {
                // ボタンが押され続けている間に実行したい処理
                switch (buttonType)
                {
                    case ButtonType.Left:
                        if (_basketController.CanMove(-1)) _basketController.Move(-1);

                        break;
                    case ButtonType.Right:
                        if (_basketController.CanMove(1)) _basketController.Move(1);
                        break;
                }
            }
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            _testImage.color = Color.red;

            if (buttonType == ButtonType.Space)
            {
                if (_laserController == null)
                    _laserController = GameObject.Find("Laser(Clone)").GetComponent<LaserController>();
                if (_laserController != null)
                {
                    _laserController.FireLaser();
                }
                else
                {
                    Debug.LogError($"_laserController is null");
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            _testImage.color = Color.blue;

        }
    }
}