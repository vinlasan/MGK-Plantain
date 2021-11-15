using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //public Notification context;
    public bool inRange;

    public bool textRequested { get; private set; }
    
    [SerializeField]
    public string descriptionText;

    [SerializeField] 
    private SpriteRenderer  normal, highlighted;

    [SerializeField] 
    private SceneStateType textOpen;

    // Use this for initialization
    protected void Start()
    {
        ChangeHighlight(false);
        textRequested = false;
    }

    protected void OnEnable()
    {
        EventManager.TextBoxStatusUpdate += CanDisplayText;
    }

    protected void OnDisable()
    {
        EventManager.TextBoxStatusUpdate -= CanDisplayText;
    }

    private void CanDisplayText(bool textStatus)
    {
        textRequested = textStatus;
    }

    public void DisplayText()
    {
        if (!textRequested)
        {
            EventManager.OnUpdateTextBox(descriptionText);
            EventManager.OnSceneStateChanged(textOpen);
            textRequested = !textRequested;
        }
        else
        {
            EventManager.OnUpdateTextBox("");
            //GameDirector.OnSceneStateChanged(textClose);
            textRequested = !textRequested;
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
            EventManager.OnInteractableInRange(this, true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            //context.Raise();
            inRange = false;
            ChangeHighlight(false);
            EventManager.OnInteractableInRange(this, false);
        }
    }
}
