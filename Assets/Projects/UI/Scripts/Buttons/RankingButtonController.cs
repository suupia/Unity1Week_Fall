using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Projects.UI.Buttons.Scripts
{
    public class RankingButtonController: ButtonAnimationOnRollOver, IPointerClickHandler
    {
        int _scoreAmount;
        public void SetScore(double scoreAmount)
        {
            _scoreAmount = (int)scoreAmount;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(_scoreAmount);

        }
    }
}