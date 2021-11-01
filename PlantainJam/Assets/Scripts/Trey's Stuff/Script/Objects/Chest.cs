using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Item contents;
    public bool isOpen;
    public Inventory playerInventory;
    //public GameObject opensfx;
    public Notification raiseItem;
    //public GameObject dialogueBox;
    //public Text dialogueText;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                voidChest();
            }
        }
    }

    public void OpenChest()
    {
        //collectible sfx on
        //opensfx.SetActive(true);
        //dialogue window on
        //dialogueBox.SetActive(true);
        //dialogue text - contents text
        //dialogueText.text = contents.itemDescription;
        //adds content to inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //Raise the notif to the player to animate
        raiseItem.Raise();
        //raise the context clue
        //context.Raise();
        //set chest to opened
        isOpen = true;
        //anim to open chest
        anim.SetBool("opened", true);

    }
    public void voidChest()
    {

        //music over
        //opensfx.SetActive(false);
        //dialogue off
        //dialogueBox.SetActive(false);
        //raise the notif to the player to stop animating
        raiseItem.Raise();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            //context.Raise();
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            //context.Raise();
            inRange = false;
        }
    }
}
