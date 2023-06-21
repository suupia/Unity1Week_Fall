using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Projects.Score.Script
{
    public enum FruitScoreType
    {
        Positive,
        Negative
    }

    [RequireComponent(typeof(TextMeshPro))]
    public class FruitScoreTextController : MonoBehaviour
    {
        [SerializeField] Color positiveColor;
        [SerializeField] Color negativeColor;

        readonly float _offsetHeight = 0.5f;
        readonly float _lifeTime = 1f;
        readonly float _moveDistance = 1f;

        public void Init(FruitScoreType type, string text)
        {
            // Debug.Log($"Init FruitScoreTextController");
            var pos = transform.position;
            transform.position = new Vector2(pos.x, pos.y + _offsetHeight);

            var color = type == FruitScoreType.Positive ? positiveColor : negativeColor;
            var textMeshPro = GetComponent<TextMeshPro>();
            var moveEndPos = transform.position.y + _moveDistance;


            DOTween.Sequence()
                .OnStart(() =>
                {
                    textMeshPro.text = text;
                    textMeshPro.alpha = 1.0f;
                    textMeshPro.color = color;
                    textMeshPro.transform.localScale = Vector3.one * 0.3f;
                })
                .Append(textMeshPro.DOFade(0.0f, _lifeTime).SetEase(Ease.InCubic))
                .Join(textMeshPro.transform.DOScale(1.0f, _lifeTime).SetEase(Ease.OutBack))
                .Join(textMeshPro.transform.DOMoveY(moveEndPos + _moveDistance, _lifeTime)
                    .SetEase(Ease.InFlash))
                .OnComplete(() => { Destroy(gameObject); })
                .Play();
        }
    }
}