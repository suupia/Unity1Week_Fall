using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Projects.BGM.Scripts
{
    public class MusicVolumeController : MonoBehaviour
    {
        [SerializeField] public Slider bgmSlider;
        [SerializeField] public Slider seSlider;
        readonly float initVolume = 0.4f;

        [Inject]
        public void Construct(MusicVolumeContainer musicVolumeContainer)
        {
            bgmSlider.value = initVolume;
            seSlider.value = initVolume;
            musicVolumeContainer.BGMVolume = initVolume;
            musicVolumeContainer.SEVolume = initVolume;
            
            bgmSlider.onValueChanged.AddListener((value) =>
            {
                musicVolumeContainer.BGMVolume = value;
            });
            seSlider.onValueChanged.AddListener((value) =>
            {
                musicVolumeContainer.SEVolume = value;
            });
        }
        
    }

    public class MusicVolumeContainer
    {
        public float BGMVolume { get; set; }
        public  float SEVolume { get; set; }
    }
}