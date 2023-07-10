using Projects.GameSystem.Interfaces;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Projects.Mobile.Scripts
{
    public class MobileButtonsManager : MonoBehaviour
    {
        [SerializeField] GameObject[] mobileButtons;
        

        [Inject]
        public void Construct(IGameStateManager gameStateManager)
        {
            
            gameStateManager.ObserveEveryValueChanged(x => x.CurrentState)
                .Where(x => x == GameState.PreparingResult)
                .Subscribe(x=>
                {
                    if(Application.isMobilePlatform)SetActiveAllButtons(x == GameState.Game);
                });
        }
        
        void SetActiveAllButtons(bool isActive)
        {
            foreach (var button in mobileButtons)
            {
                button.SetActive(isActive);
            }
        }
    }
}