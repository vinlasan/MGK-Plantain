using System;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "NewState", menuName = "SceneManagement/StateType"), Serializable]
    public class SceneStateType : ScriptableObject
    {
        [SerializeField]
        private string sceneStateDescription;

        [SerializeField] 
        private bool returnToPreviousScene, tempState;

        public string sceneType
        {
            get { return this.name; }
        }

        public bool backToScene
        {
            get { return returnToPreviousScene; }
        }

        public bool nonStoredState
        {
            get { return tempState; }
        }
    }
}