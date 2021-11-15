using UnityEngine;
using Fungus;
using EventHandler = Fungus.EventHandler;
using Gameplay;

namespace FungusExtensions
{
    [EventHandlerInfo("Custom", "Scene state Event", "This block will Execute when the the matching scene state type is broadcast by an event")]
    [AddComponentMenu("")]
    public class SceneStateEventHandler : EventHandler
    {
        [Tooltip("Scene state that matches so we can trigger")]
        [SerializeField]
        private SceneStateType sceneStateType;

        private void Awake()
        {
            if(!sceneStateType)
                Debug.LogError("Scene state type needs to be assigned in the flowchart for this block: " + this.parentBlock);
        }

        private void OnEnable()
        {
            EventManager.SceneStateChange += ExecuteBlock;
        }

        private void OnDisable()
        {
            EventManager.SceneStateChange -= ExecuteBlock;
        }

        private void ExecuteBlock(SceneStateType inputScene)
        {
            if(inputScene == sceneStateType) 
                ExecuteBlock();
        }
    }
}