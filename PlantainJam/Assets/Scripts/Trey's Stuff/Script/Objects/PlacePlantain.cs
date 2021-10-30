using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Plantain
{
    key,
}
public class PlacePlantain : Interactable
{
    public Plantain thisChip;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer plantainSprite;
    public BoxCollider2D physicsCollider;



    private void Update()
    {
        {
            if (playerInventory.numberOfKeys >= 1)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (inRange && thisChip == Plantain.key)
                    {
                        //checks if player has key
                        if (playerInventory.numberOfKeys > 0)
                        {
                            //removes a player key
                            playerInventory.numberOfKeys--;
                        }
                        //if player does, call drop
                        Drop();
                    }
                }
            }
        }
    }

    public void Drop()
    {
        //turn the door's sprite renderer off
        plantainSprite.enabled = true;
        //set open to true
        //open = true;
        //turns off door box collider
        //physicsCollider.enabled = false;
    }

    public void Close()
    {

    }
}
