using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : Interactable 
    {
        //TODO Create function playing sounds on pickup or put down
        public bool pickedUp { get; private set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            base.OnTriggerEnter2D(col);
            if(col.CompareTag("Player"))
                EventManager.OnInteractableInRange(this, true);
            if (col.TryGetComponent(out WallSwitcher wall))
                wall.EnableSpiritWorldTraverse();
        }
        
        protected override void OnTriggerExit2D(Collider2D col)
        {
            base.OnTriggerExit2D(col);
            if(col.CompareTag("Player"))
                EventManager.OnInteractableInRange(this, false);
            if(col.TryGetComponent(out WallSwitcher wall))
                wall.DisableSpiritWorldTraverse();
        }

        public void Pickup()
        {
            pickedUp = true;
            
            //play sound
            //tween towards player
            gameObject.SetActive(false);
        }

        public void Place(Vector3 position)
        {
            gameObject.transform.position = position;
            gameObject.SetActive(true);
            pickedUp = false;
        }
    }
}