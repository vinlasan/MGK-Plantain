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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInventory.AddItem(contents);
            playerInventory.currentItem = contents;
            Destroy(this.gameObject);
        }
    }
}
