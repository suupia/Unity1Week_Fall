using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Projects.UI.Buttons.Scripts
{
    public class StartGameButton: ButtonAnimationOnRollOver, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}