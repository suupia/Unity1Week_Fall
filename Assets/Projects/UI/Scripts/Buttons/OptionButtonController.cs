using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Projects.UI.Buttons.Scripts
{
    public class OptionButtonController :  ButtonAnimationOnRollOver, IPointerClickHandler
    {
        [SerializeField] GameObject optionParent;
        IGameStateManager _gameStateManager;
        
        [Inject]
        public void Construct(IGameStateManager gameStateManger)
        {
            _gameStateManager = gameStateManger;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            optionParent.SetActive(true);
            _gameStateManager.ChangeState(GameState.Option);

        }
    }

}
