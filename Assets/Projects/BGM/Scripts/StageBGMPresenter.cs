using System;
using System.Linq;
using DG.Tweening;
using Level.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
namespace Projects.BGM.Scripts
{
    // public class StateBGMPresenter : MonoBehaviour
    // {
    //     AudioSource[] _bgmAudioSources;
    //     readonly float _duration = 0.5f; // ボリュームを変更する時間（秒）
    //     float _targetVolume ; // 目指すボリューム
    //
    //     [Inject]
    //     public void Construct(ILevelManager levelManager, MusicVolumeController musicVolume)
    //     {
    //         _bgmAudioSources = GetComponentsInChildren<AudioSource>();
    //         this.ObserveEveryValueChanged(_ => levelManager.CurrentLevel)
    //             .Subscribe(level =>
    //             {
    //                 if (level < _bgmAudioSources.Length)
    //                 {
    //                     // 0番目にはイントロが入っている
    //                     _bgmAudioSources[level + 1].DOFade(_targetVolume, _duration).SetEase(Ease.InQuad);
    //                 }
    //             });
    //         musicVolume.bgmSlider.OnValueChangedAsObservable()
    //             .Subscribe(x => _targetVolume = x);
    //     }
    //
    //     public void PlayBGM()
    //     {
    //         // イントロとメロディ＆ベースは最初から流す
    //         _bgmAudioSources[0].volume = _targetVolume;
    //         _bgmAudioSources[1].volume =  _targetVolume;
    //
    //         foreach (var bgmAudioSource in _bgmAudioSources)
    //         {
    //             bgmAudioSource.Play();
    //         }
    //     }
    //     
    // }
    public class StageBGMPresenter : MonoBehaviour
    {
        [Serializable]
        public class AudioState
        {
            public AudioSource AudioSource;
            public bool IsFadingIn;
        }

        AudioState[] _bgmAudioStates;
        readonly float _duration = 0.5f; // ボリュームを変更する時間（秒）
        float _targetVolume ; // 目指すボリューム

        [Inject]
        public void Construct(ILevelManager levelManager, MusicVolumeContainer musicVolume)
        {
            // AudioSourceに対応するAudioStateの配列を生成します。
            _bgmAudioStates = GetComponentsInChildren<AudioSource>().Select(audioSource => new AudioState { AudioSource = audioSource, IsFadingIn = false }).ToArray();

            this.ObserveEveryValueChanged(_ => levelManager.CurrentLevel)
                .Subscribe(level =>
                {
                    if (level < _bgmAudioStates.Length)
                    {
                        // 0番目にはイントロが入っている
                        var audioState = _bgmAudioStates[level + 1];
                        audioState.IsFadingIn = true;  // フェードイン開始
                        audioState.AudioSource.DOFade(_targetVolume, _duration).SetEase(Ease.InQuad).OnComplete(() => audioState.IsFadingIn = false); // フェードイン終了後、フラグを下ろす
                    }
                });

            musicVolume.ObserveEveryValueChanged(x => x.BGMVolume)
                .Subscribe(x => {
                    _targetVolume = x;
                    foreach (var audioState in _bgmAudioStates)
                    {
                        if (!audioState.IsFadingIn)  // フェードイン中でなければ
                        {
                            audioState.AudioSource.volume = x;
                        }
                    }
                });
        }

        public void PlayBGM()
        {
            // イントロとメロディ＆ベースは最初から流す
            _bgmAudioStates[0].AudioSource.volume = _targetVolume;
            _bgmAudioStates[1].AudioSource.volume =  _targetVolume;

            foreach (var audioState in _bgmAudioStates)
            {
                audioState.AudioSource.Play();
            }
        }
    }
}