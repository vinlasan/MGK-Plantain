using System;
using UnityEngine;
using Gameplay;
using TMPro;
using System.Collections.Generic;

namespace UI
{
    public class ObjectiveText : MonoBehaviour
    {
        [SerializeField]
        private SceneStateType enableTextBox, disableTextBox;

        [SerializeField] 
        private GameObject canvasObject = default;
        
        [SerializeField]
        private TextMeshProUGUI textObject = default;

        [SerializeField]
        private List<ObjectiveTextData> objectiveTextData = default;
        
        [SerializeField]
        private GameObject objectiveBoxObject = default;

        private void Awake()
        {
            OnSceneStateChanged(disableTextBox);
        }

        private void OnEnable()
        {
            EventManager.SceneStateChange += OnSceneStateChanged;
        }

        private void OnDisable()
        {
            EventManager.SceneStateChange -= OnSceneStateChanged;
        }

        //Check if the scenestate is one that correlates to an objective text. If so update the text object
        private void OnSceneStateChanged(SceneStateType stateType)
        {
            foreach (ObjectiveTextData objTextData in objectiveTextData)
            {
                if(objTextData.sceneStateType == stateType)
                    textObject.text = objTextData.text;
            }

            if (stateType == enableTextBox)
            {
                canvasObject.SetActive(true);
                objectiveBoxObject.SetActive(true);
            }
            else if (stateType == disableTextBox)
            {
                canvasObject.SetActive(false);
                objectiveBoxObject.SetActive(false);
            }
        }
    }
    
    [Serializable]
    public class ObjectiveTextData
    {
        public SceneStateType sceneStateType;
        public string text;
    }
}