using System.Collections;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : Interactable 
    {
        public bool isDown;
        public Item contents;
        public Inventory playerInventory;
        public Notification raiseItem;
        //Collider2D colision;
        //TODO Create function playing sounds on pickup or put down

        
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            base.OnTriggerEnter2D(col);
            if (col.TryGetComponent(out WallSwitcher wall))
                wall.EnableSpiritWorldTraverse();
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && inRange)
            {
                if (!isDown)
                {
                    Collect();
                    this.gameObject.SetActive(false);
                    //Destroy(this.gameObject);
                }
                else
                {
                    Place();
                    /*
                    if (playerInventory.Equals(1))
                    {

                    }
                    */
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                    //checks if player has key
                    if (playerInventory.numberOfKeys > 0)
                    {
                        //removes a player key
                        playerInventory.numberOfKeys--;
                    //this.gameObject.SetActive(true);
                    //transform.position = Input.mousePosition;
                        
                    }
                
            }
        }

        public void Collect()
        {
            /*
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                playerInventory.AddItem(contents);
                playerInventory.currentItem = contents;
                Destroy(this.gameObject);
            }
            */
            

           playerInventory.AddItem(contents);
           playerInventory.currentItem = contents;
           Destroy(this.gameObject);

            //Extra stuff for future purposes below:
            //collectible sfx on
            //collectsfx.SetActive(true);
            //dialogue window on
            //dialogueBox.SetActive(true);
            //dialogue text - contents text
            //dialogueText.text = contents.itemDescription;
            //adds content to inventory
            //playerInventory.AddItem(contents);
            //playerInventory.currentItem = contents;
            //Raise the notif to the player to animate
            //raiseItem.Raise();
            //raise the context clue
            //context.Raise();
            //set chest to opened
            //isOpen = true;
            //anim to open chest
            //anim.SetBool("opened", true);

        }
        public void Place()
        {


            //music over
            //placefx.SetActive(false);
            //dialogue off
            //dialogueBox.SetActive(false);
            //raise the notif to the player to stop animating
            //raiseItem.Raise();


        }


        protected override void OnTriggerExit2D(Collider2D col)
        {
            base.OnTriggerExit2D(col);
            if(col.TryGetComponent(out WallSwitcher wall))
                wall.DisableSpiritWorldTraverse();
        }
    }
}