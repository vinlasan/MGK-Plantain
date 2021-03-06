using Gameplay;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool inRange;

    public bool textRequested { get; private set; }

    [SerializeField, Tooltip("Only change this in editor for testing purposes")]
    protected bool hasRecord; 
    protected bool interactionActive;
    
    [SerializeField]
    public string descriptionText, recordFoundText;

    [SerializeField] 
    protected SpriteRenderer  normal, highlighted;

    [SerializeField] 
    protected SceneStateType textOpen, textActiveScene, recordFoundScene;

    public bool HasRecord
    {
        get { return hasRecord; }
    }

    // Use this for initialization
    protected void Start()
    {
        ChangeHighlight(false);
        textRequested = false;
        interactionActive = false;
    }

    protected virtual void OnEnable()
    {
        EventManager.TextBoxStatusUpdate += CanDisplayText;
        EventManager.SceneStateChange += ActivateInteraction;
    }

    protected virtual void OnDisable()
    {
        EventManager.TextBoxStatusUpdate -= CanDisplayText;
        EventManager.SceneStateChange -= ActivateInteraction;
    }

    protected void CanDisplayText(bool textStatus)
    {
        textRequested = textStatus;
    }

    protected virtual void ActivateInteraction(SceneStateType sceneStateType)
    {
        if (textActiveScene == sceneStateType)
            interactionActive = true;
    }

    public void DisplayText()
    {
        if (!textRequested)
        {
            string text = descriptionText;
            if (hasRecord)
            {
                text = recordFoundText + "\n" + descriptionText;
                hasRecord = false;
                EventManager.OnSceneStateChanged(recordFoundScene);
            }
            EventManager.OnUpdateTextBox(text);
            EventManager.OnSceneStateChanged(textOpen);
            textRequested = !textRequested;
        }
        else
        {
            EventManager.OnUpdateTextBox("");
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
        if (interactionActive && collision.CompareTag("Player") && !collision.isTrigger)
        {
            inRange = true;
            ChangeHighlight(true);
            EventManager.OnInteractableInRange(this, true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (interactionActive && collision.CompareTag("Player") && !collision.isTrigger)
        {
            inRange = false;
            ChangeHighlight(false);
            EventManager.OnInteractableInRange(this, false);
        }
    }
}
