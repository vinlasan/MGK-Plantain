using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class SceneState
    {
        public SceneStateType sceneStateType;
        
        [SerializeField]
        private bool enablePlayerMovement;

        [SerializeField]
        private WorldMode worldMode;

        [SerializeField]
        private GameObject[] sceneObjectsToEnable;

        public void InitState()
        {
            SetSceneObjects(false);
        }
        
        public void EnterState()
        {
            SetSceneObjects(true);
            EventManager.OnTogglePlayerMovement(enablePlayerMovement);
            EventManager.OnWorldTypeChanged(worldMode);
        }

        public void ExitState()
        {
            SetSceneObjects(false);
            EventManager.OnTogglePlayerMovement(enablePlayerMovement);
        }

        private void SetSceneObjects(bool enable)
        {
            if (sceneObjectsToEnable != null && sceneObjectsToEnable.Length != 0)
            {
                foreach (GameObject t in sceneObjectsToEnable)
                { 
                    if(t) t.SetActive(enable);
                }
            }
        }
    }
}