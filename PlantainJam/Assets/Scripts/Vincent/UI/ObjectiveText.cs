using System;
using UnityEngine;
using Gameplay;
using TMPro;
using System.Collections.Generic;

namespace UI
{
    public class ObjectiveText : MonoBehaviour
    {
        //enable the objective box 
        //an event fires with the text to update 
        //use scene states to determine when to enable the scene state and disable it
        
        [SerializeField]
        private SceneStateType enableTextBox, disableTextBox;
        [SerializeField]
        private TextMeshProUGUI textObject;

        [SerializeField]
        private List<ObjectiveTextData> objectiveTextData;
        
        [SerializeField]
        private GameObject objectiveBoxObject;

        private void Awake()
        {
            textObject = GetComponentInChildren<TextMeshProUGUI>();
            HandleSceneState(disableTextBox);
        }

        private void OnEnable()
        {
            EventManager.SceneStateChange += HandleSceneState;
        }

        private void OnDisable()
        {
            EventManager.SceneStateChange -= HandleSceneState;
        }

        //Check if the scenestate is one that correlates to an objective text. If so update the text object
        private void HandleSceneState(SceneStateType stateType)
        {
            foreach (ObjectiveTextData objTextData in objectiveTextData)
            {
                if(objTextData.sceneStateType == stateType)
                    textObject.text = objTextData.text;
            }
            
            if (stateType == enableTextBox)
                objectiveBoxObject.SetActive(true);
            else if (stateType == disableTextBox)
                objectiveBoxObject.SetActive(false);
        }
    }
    
    [Serializable]
    public class ObjectiveTextData
    {
        public SceneStateType sceneStateType;
        public string text;
    }
}