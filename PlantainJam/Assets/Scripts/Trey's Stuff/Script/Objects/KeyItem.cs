using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItem : Interactable
{
    public Item contents;
    //public bool isOpen;
    public Inventory playerInventory;
    //public GameObject collectsfx;
    public Notification raiseItem;
    //public Collider2D colision;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * if (Input.GetKeyDown(KeyCode.Space))
        {
            //Collider2D colision;
            if (colision.CompareTag("Player") && !colision.isTrigger)
            {
                playerInventory.AddItem(contents);
                playerInventory.currentItem = contents;
                Destroy(this.gameObject);
            }
        }
        */
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space) && !collision.isTrigger)
            {
                playerInventory.AddItem(contents);
                playerInventory.currentItem = contents;
                Destroy(this.gameObject);
            }
        }
     
    }
    
}
