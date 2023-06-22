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
        [SerializeField] Image backGroundImage;
        [SerializeField] Sprite[] backGroundSprites;
        
        [Inject]
        public void Construct(ILevelManager levelManager)
        {
            this.ObserveEveryValueChanged(_ => levelManager.CurrentLevel)
                .Subscribe(level =>
                {
                    if (level < backGroundSprites.Length)
                    {
                        backGroundImage.sprite = backGroundSprites[level];
                    }
                });
        }
    }
}