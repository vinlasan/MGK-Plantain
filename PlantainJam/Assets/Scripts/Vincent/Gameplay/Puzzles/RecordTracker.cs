using UnityEngine;

namespace Gameplay.Puzzle
{
    public class RecordTracker : MonoBehaviour
    {
        [SerializeField]
        private int totalRecordCount, currentRecordCount;

        [SerializeField] 
        private SceneStateType recordsFoundSceneState, recordsAllFoundSceneState;

        private void Start()
        {
            //get all of the interactables, if they are marked as records increase the count
            //subscribe to the record found event
            //each time the event fires increase the current record count
            //if current count equals total count fire the scene state event

            totalRecordCount = 0;
            currentRecordCount = 0;

            Interactable[] interactables = FindObjectsOfType<Interactable>(true);

            foreach (Interactable interactable in interactables)
            {
                if (interactable.HasRecord)
                    totalRecordCount++;
            }
        }

        private void OnEnable()
        {
            EventManager.SceneStateChange += RecordsFoundHandler;
        }

        private void OnDisable()
        {
            EventManager.SceneStateChange -= RecordsFoundHandler;
        }

        private void RecordsFoundHandler(SceneStateType sceneStateType)
        {
            if (recordsFoundSceneState == sceneStateType)
            {
                currentRecordCount++;

                if (totalRecordCount == currentRecordCount)
                    EventManager.OnSceneStateChanged(recordsAllFoundSceneState);
                
            }
        }
    }
}