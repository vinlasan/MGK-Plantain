using System;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "NewState", menuName = "SceneManagement/StateType"), Serializable]
    public class SceneStateType : ScriptableObject
    {
        [SerializeField]
        private string sceneStateName;

        public string sceneType
        {
            get { return sceneStateName; }
        }
    }
}