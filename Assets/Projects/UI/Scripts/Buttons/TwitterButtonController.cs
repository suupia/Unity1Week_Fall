using System.Collections;
using System.Collections.Generic;
using Projects.UI.Buttons.Scripts;
using Projects.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Projects.UI.Buttons.Scripts
{
    public class TwitterButtonController : ButtonAnimationOnRollOver, IPointerClickHandler
    {
        string _scoreText;
        public void SetScore(double scoreAmount)
        {
            _scoreText = NumberFormatter.FormatNumber(scoreAmount);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            naichilab.UnityRoomTweet.Tweet("doubling-fruit-rain", $"[Doubling Fruit Rain]　スコア：{_scoreText}", "unityroom", "unity1week");
        }
    }
}