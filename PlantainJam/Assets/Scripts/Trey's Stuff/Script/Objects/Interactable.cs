using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //public Notification context;
    public bool inRange;

    private bool textRequested;
    
    [SerializeField]
    private string descriptionText;

    [SerializeField] 
    private SpriteRenderer  normal, highlighted;

    [SerializeField] 
    private SceneStateType textOpen, textClose;

    // Use this for initialization
    protected void Start()
    {
        ChangeHighlight(false);
        textRequested = false;
    }

    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //if the dialogue has not been requested -> show display & update box
                //otherwise request the box closes & set text to ""
                textRequested = !textRequested;
                if (!textRequested)
                {
                    EventManager.OnUpdateTextBox(descriptionText);
                    GameDirector.OnSceneStateChanged(textOpen);
                }
                else
                {
                    EventManager.OnUpdateTextBox("");
                    GameDirector.OnSceneStateChanged(textClose);
                }
            }
        }
    }

    protected void ChangeHighlight(bool highlightActive)
    {
        if(normal)
            normal.gameObject.SetActive(!highlightActive);
        if (highlighted)
            highlighted.gameObject.SetActive(highlightActive);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //context.Raise();
            inRange = true;
            ChangeHighlight(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //context.Raise();
            inRange = false;
            ChangeHighlight(false);
        }
    }
}
