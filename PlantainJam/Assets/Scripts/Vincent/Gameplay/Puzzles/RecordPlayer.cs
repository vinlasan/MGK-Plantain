using UnityEngine;

namespace Gameplay.Puzzle
{
    public class RecordPlayer : Interactable
    {
        [SerializeField]
        private SceneStateType recordsAllFoundSceneState, recordPuzzleOpenState;

        private bool showRecordMenu;
        
        //this needs disable the interaction text when the records are found
        //subscribe to records found event
        //when interacted with fire the scene state event to open the menu options\

        protected override void ActivateInteraction(SceneStateType sceneStateType)
        {
            if (sceneStateType == recordsAllFoundSceneState)
                showRecordMenu = true;
            base.ActivateInteraction(sceneStateType);
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (interactionActive && collision.CompareTag("Player") && !collision.isTrigger && showRecordMenu)
            {
                EventManager.OnSceneStateChanged(recordPuzzleOpenState);
            }
            
            base.OnTriggerEnter2D(collision);
        }
    }
}