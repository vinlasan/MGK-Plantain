using Fungus;
using UnityEngine;
using Gameplay;

namespace FungusExtensions
{
    [CommandInfo("Custom", "SceneStateCommand", "Send a scene state command for the Director to change to")]
    [AddComponentMenu("")]
    public class SceneStateCommand : Command
    {
        [Tooltip("A description of what this command does. Appears in the command summary.")]
        [SerializeField] protected string description = "";
        
        [Tooltip("The scene state type to send to the Director")]
        [SerializeField] private SceneStateType sceneStateType;

        public override void OnEnter()
        {
            if(sceneStateType)
                EventManager.OnSceneStateChanged(sceneStateType);
            Continue();
        }
        
        public override string GetSummary()
        {
            if (sceneStateType)
                return sceneStateType.name;
            
            if (!string.IsNullOrEmpty(description))
                return description;

            return "";
        }
    }
}