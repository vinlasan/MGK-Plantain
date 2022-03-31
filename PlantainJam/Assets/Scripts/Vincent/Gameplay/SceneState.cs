using System;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class SceneState
    {
        public SceneStateType sceneStateType;
        
        [SerializeField]
        private bool ignoreWorldType, dontDisableObjectsOnExit;

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
            if(!ignoreWorldType)
                EventManager.OnWorldTypeChanged(worldMode);
        }

        public void ExitState()
        {
            if(!dontDisableObjectsOnExit)
                SetSceneObjects(false, sceneObjectsToEnable);
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