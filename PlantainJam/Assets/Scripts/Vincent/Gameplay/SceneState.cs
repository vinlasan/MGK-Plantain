using System;
using UnityEngine;

namespace Gameplay
{
    public class SceneState : MonoBehaviour
    {
        [SerializeField]
        private bool disablePlayerMovement;

        [SerializeField] 
        private Transform[] sceneObjectsToEnable;

        public void Awake()
        {
            SetSceneObjects(false);
        }

        public void InitializeState()
        {
            SetSceneObjects(true);
        }

        public void ExitState()
        {
            SetSceneObjects(false);
        }

        private void SetSceneObjects(bool enable)
        {
            if (sceneObjectsToEnable != null && sceneObjectsToEnable.Length != 0)
            {
                foreach (Transform t in sceneObjectsToEnable)
                {
                    t.gameObject.SetActive(enable);
                }
            }
        }
    }
}