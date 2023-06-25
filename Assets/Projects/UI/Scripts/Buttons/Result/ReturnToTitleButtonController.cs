using System.Collections;
using System.Collections.Generic;
using Projects.UI.Buttons.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Projects.UI.Buttons.Scripts
{
    public class ReturnToTitleButtonController : ButtonAnimationOnRollOver, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(0);
        }
    }
}