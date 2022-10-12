using UnityEngine;

namespace Gameplay.Puzzle
{
    public class RecordPlayer : Interactable
    {
        [SerializeField]
        private SceneStateType recordsAllFoundSceneState, 
            recordPuzzleOpenState, 
            recordPuzzleClose;

        private bool showRecordMenu;
        

        protected override void ActivateInteraction(SceneStateType sceneStateType)
        {
            if (sceneStateType == recordsAllFoundSceneState)
                showRecordMenu = true;
            if (sceneStateType == recordPuzzleClose)
                showRecordMenu = false;
            base.ActivateInteraction(sceneStateType);
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (interactionActive && collision.CompareTag("Player") && !collision.isTrigger && showRecordMenu)
            {
                base.OnTriggerEnter2D(collision);
                EventManager.OnSceneStateChanged(recordPuzzleOpenState);
            }
            
            
        }
    }
}