using System.Collections;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : Interactable 
    {
        //TODO Create function playing sounds on pickup or put down
        
        protected void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out WallSwitcher wall))
                wall.EnableSpiritWorldTraverse();
        }

        protected void OnTriggerExit2D(Collider2D col)
        {
            if(col.TryGetComponent(out WallSwitcher wall))
                wall.DisableSpiritWorldTraverse();
        }
    }
}