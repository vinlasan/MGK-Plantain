using Fungus;
using Gameplay;
using UnityEngine;
using EventHandler = Fungus.EventHandler;

namespace FungusExtensions
{
    [EventHandlerInfo("Text", "Text Event", "This block will Execute when the ")]
    [AddComponentMenu("")]
    public class TextEventHandler : EventHandler
    {
        [VariableProperty(typeof(StringVariable))]
        public StringVariable outTextValue;
        
        //[SerializeField]
        //public StringData textToUpdate;
        

        private void OnEnable()
        {
            EventManager.UpdateTextBox += ExecuteBlock;
        }

        private void OnDisable()
        {
            EventManager.UpdateTextBox -= ExecuteBlock;
        }

        private void ExecuteBlock(string text)
        {
            //textToUpdate.stringVal = text;
            if(outTextValue)
                outTextValue.Value = text;
            ExecuteBlock();
        }
    }
}