using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Projects.UI.Buttons.Scripts
{
    public class ShowOperationExplanationButton : ButtonAnimationOnRollOver, IPointerClickHandler
    {
        [SerializeField] GameObject titleCanvas;
        [SerializeField] GameObject optionExplanationCanvas;

        public void OnPointerClick(PointerEventData eventData)
        {
            titleCanvas.SetActive(false);
            optionExplanationCanvas.SetActive(true);
        }
    }
}