using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class SceneState
    {
        public SceneStateType sceneStateType;
        
        [SerializeField]
        private bool enablePlayerMovement, ignoreWorldType, dontDisableObjectsOnExit;

        [SerializeField]
        private WorldMode worldMode;

        [SerializeField]
        private GameObject[] sceneObjectsToEnable, sceneObjectsToDisable;
        

        public void InitState()
        {
            SetSceneObjects(false, sceneObjectsToEnable);
        }
        
        public void EnterState()
        {
            SetSceneObjects(true, sceneObjectsToEnable);
            SetSceneObjects(false, sceneObjectsToDisable);
            EventManager.OnTogglePlayerMovement(enablePlayerMovement);
            if(!ignoreWorldType)
                EventManager.OnWorldTypeChanged(worldMode);
        }

        public void ExitState()
        {
            if(!dontDisableObjectsOnExit)
                SetSceneObjects(false, sceneObjectsToEnable);
            EventManager.OnTogglePlayerMovement(enablePlayerMovement);
        }

        private void SetSceneObjects(bool enable, GameObject[] objects)
        {
            if (objects != null && objects.Length != 0)
            {
                foreach (GameObject t in objects)
                { 
                    if(t) t.SetActive(enable);
                }
            }
        }
    }
}