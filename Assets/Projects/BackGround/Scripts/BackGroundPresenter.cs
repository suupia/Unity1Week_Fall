using DG.Tweening;
using Level.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using Image = UnityEngine.UI.Image;

namespace BackGround.Scripts
{
    public class BackGroundPresenter : MonoBehaviour
    {
        [SerializeField]  Image backGroundImage;
        [SerializeField] Image backGroundTransitionImage; // 切り替わる時のフェードイン用
        [SerializeField]  Sprite[] backGroundSprites;
        [SerializeField]  float transitionDuration = 1f;
        

        [Inject]
        public void Construct(ILevelManager levelManager)
        {
            this.ObserveEveryValueChanged(_ => levelManager.CurrentLevel)
                .Subscribe(level =>
                {
                    if (level < backGroundSprites.Length)
                    {
                        DOTween.Sequence()
                            .OnStart(() =>
                            {
                                // transitionImageのspriteを次の者にする
                                backGroundTransitionImage.sprite = backGroundSprites[level];
                                // 透明度を0にする
                                var color = backGroundTransitionImage.color;
                                backGroundTransitionImage.color = new Color(color.r, color.g, color.b, 0);
                            })
                            .Append(backGroundTransitionImage.DOFade(1f, transitionDuration).SetEase(Ease.InCubic))
                            .Append(backGroundImage.DOFade(0f, transitionDuration).SetEase(Ease.OutCubic))
                            .OnComplete(() =>
                            {
                                backGroundImage.sprite = backGroundSprites[level];
                                backGroundImage.color = new Color(1, 1, 1, 1);
                                backGroundTransitionImage.color = new Color(1, 1, 1, 0);
                            })
                            .Play();
                    }
                });
        }
        
    }
}