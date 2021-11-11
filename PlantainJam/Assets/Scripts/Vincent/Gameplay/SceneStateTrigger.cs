using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class SceneStateTrigger : MonoBehaviour
    {
        [SerializeField]
        private SceneStateType stateToTransitionTo;

        [SerializeField] private UnityEvent triggerEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.CompareTag("Player"))
                return;
            if(triggerEvent != null)
                triggerEvent.Invoke();
            if (stateToTransitionTo != null)
                GameDirector.OnSceneStateChanged(stateToTransitionTo);
            else Debug.LogError(String.Format("Assign a Scene State for the {0} trigger ", this.name));
        }
    }
}