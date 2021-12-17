using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class SceneStateTrigger : MonoBehaviour
    {
        [SerializeField] 
        private List<SceneStateType> sceneStatesToTrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.CompareTag("Player"))
                return;
            if (sceneStatesToTrigger != null)
            {
                foreach (SceneStateType stateType in sceneStatesToTrigger)
                {
                    EventManager.OnSceneStateChanged(stateType);
                }
            }
            else Debug.LogError(String.Format("Assign a Scene State for the {0} trigger ", this.name));
        }
        
        
    }
}