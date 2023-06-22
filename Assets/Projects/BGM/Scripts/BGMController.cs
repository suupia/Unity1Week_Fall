using DG.Tweening;
using Level.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
namespace BGM.Scripts
{
    public class BGMController : MonoBehaviour
    {
        AudioSource[] _bgmAudioSources;
        readonly float _duration = 0.5f; // ボリュームを変更する時間（秒）
        readonly float _targetVolume = 1f; // 目指すボリューム

        [Inject]
        public void Construct(ILevelManager levelManager)
        {
            _bgmAudioSources = GetComponentsInChildren<AudioSource>();
            this.ObserveEveryValueChanged(_ => levelManager.CurrentLevel)
                .Subscribe(level =>
                {
                    if (level < _bgmAudioSources.Length)
                    {
                        // 0番目にはイントロが入っている
                        _bgmAudioSources[level + 1].DOFade(_targetVolume, _duration).SetEase(Ease.InQuad);
                    }
                });
        }

        public void PlayBGM()
        {
            // イントロとメロディ＆ベースは最初から流す
            _bgmAudioSources[0].volume = _targetVolume;
            _bgmAudioSources[1].volume =  _targetVolume;

            foreach (var bgmAudioSource in _bgmAudioSources)
            {
                bgmAudioSource.Play();
            }
        }
    }
}