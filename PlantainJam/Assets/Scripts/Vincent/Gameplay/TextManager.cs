using System;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textObject;

        private void Start()
        {
            if(!textObject)
                Debug.LogError("Assign the text holder for: " + this.name);
        }

        private void OnEnable()
        {
            EventManager.UpdateTextBox += UpdateText;
        }

        private void OnDisable()
        {
            EventManager.UpdateTextBox -= UpdateText;
        }

        private void UpdateText(string text)
        {
            textObject.text = text;
        }
        
    }
}