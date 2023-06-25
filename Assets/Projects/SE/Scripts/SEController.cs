using UnityEngine;
using VContainer;

namespace Projects.SE.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class SEController : MonoBehaviour
    {
        [SerializeField] AudioClip fireLaserSE;
        [SerializeField] AudioClip getFruitSE;
        [SerializeField] AudioClip levelUpSE;
        AudioSource _seAudioSource;
        
        [Inject]
        public void Construct()
        {
            _seAudioSource = GetComponent<AudioSource>();
        }
        
        public void PlayFireLaserSE()
        {
            _seAudioSource.clip = fireLaserSE;
            _seAudioSource.PlayOneShot(fireLaserSE);
        }
        public void PlayGetFruitSE()
        {
            _seAudioSource.clip = getFruitSE;
            _seAudioSource.PlayOneShot(getFruitSE);
        }

        public void PlayLevelUpSE()
        {
            _seAudioSource.clip = levelUpSE;
            _seAudioSource.PlayOneShot(levelUpSE);
        }
    }
}