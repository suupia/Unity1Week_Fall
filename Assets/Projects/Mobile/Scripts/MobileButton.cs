using Projects.Player.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Projects.Mobile.Scripts
{
    enum ButtonType
    {
        Left,
        Right,
        Space,
    }

    public class MobileButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] ButtonType buttonType; // インスペクター上で設定
        bool isPressed;

        BasketController _basketController;
        LaserController _laserController;

        void Start()
        {
            // if(Application.isMobilePlatform)
            //     gameObject.SetActive(true);
            // else
            //     gameObject.SetActive(false);

            // basketControllerをヒエラルキー上から取得する
            _basketController = GameObject.Find("Basket").GetComponent<BasketController>();

            // laserControllerは動的に生成されるため、Start()で取得できない
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
        }
    }
}