using System;
using UnityEngine;

namespace Gameplay
{
    public class SceneStateTrigger : MonoBehaviour
    {
        [SerializeField]
        private SceneStateType stateToTransitionTo;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.CompareTag("Player"))
                return;
            if (stateToTransitionTo != null)
                EventManager.OnSceneStateChanged(stateToTransitionTo);
            else Debug.LogError(String.Format("Assign a Scene State for the {0} trigger ", this.name));
        }
    }
}