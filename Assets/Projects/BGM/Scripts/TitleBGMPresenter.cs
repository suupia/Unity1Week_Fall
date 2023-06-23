using DG.Tweening;
using Level.Interfaces;
using UniRx;
using UnityEngine;
using VContainer;

namespace Projects.BGM.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class TitleBGMPresenter : MonoBehaviour
    {
        AudioSource _bgmAudioSources;
        readonly float _duration = 0.5f; // ボリュームを変更する時間（秒）
        readonly float _targetVolume = 1f; // 目指すボリューム

        [Inject]
        public void Construct(MusicVolumeContainer musicVolume)
        {
            _bgmAudioSources = GetComponent<AudioSource>();
            musicVolume.ObserveEveryValueChanged(x => x.BGMVolume)
                .Subscribe(x => _bgmAudioSources.volume = x);
        }

        public void PlayBGM()
        {

            _bgmAudioSources.volume = _targetVolume;

            _bgmAudioSources.Play();
            
        }
    }
}