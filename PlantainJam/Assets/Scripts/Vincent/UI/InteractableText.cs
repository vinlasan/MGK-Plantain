using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class InteractableText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textObject;
        
        [SerializeField]
        private UnityEvent TextDisplayEvent;

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
            //textObject.text = text;
            if(TextDisplayEvent ==  null)
                textObject.text = text;
            else TextDisplayEvent.Invoke();
        }

        public void TextBoxStatus(bool open)
        {
            EventManager.OnTextBoxStatusUpdate(open);
        }
    }
}