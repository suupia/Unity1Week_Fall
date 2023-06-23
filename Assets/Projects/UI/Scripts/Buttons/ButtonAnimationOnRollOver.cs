using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Projects.UI.Buttons.Scripts
{
    public abstract class ButtonAnimationOnRollOver : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        readonly float _rate = 1.15f; // どのくらい拡大するか
        Vector3 _baseScale;

        protected override void Start()
        {
            base.Start();
            _baseScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(_baseScale * _rate, 0.25f)
                .SetEase(Ease.OutExpo)
                .Play();
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(_baseScale , 0.25f)
                .SetEase(Ease.OutExpo)
                .Play();
        }
    }

}
