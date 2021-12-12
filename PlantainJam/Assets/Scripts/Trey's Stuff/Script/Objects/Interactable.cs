using Gameplay;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool inRange;

    public bool textRequested { get; private set; }

    [SerializeField, Tooltip("Only change this in editor for testing purposes")]
    private bool hasRecord; 
    private bool interactionActive;
    
    [SerializeField]
    public string descriptionText, recordFoundText;

    [SerializeField] 
    private SpriteRenderer  normal, highlighted;

    [SerializeField] 
    private SceneStateType textOpen, textActiveScene;

    // Use this for initialization
    protected void Start()
    {
        ChangeHighlight(false);
        textRequested = false;
        interactionActive = false;
    }

    protected void OnEnable()
    {
        EventManager.TextBoxStatusUpdate += CanDisplayText;
        EventManager.SceneStateChange += ActivateInteraction;
    }

    protected void OnDisable()
    {
        EventManager.TextBoxStatusUpdate -= CanDisplayText;
        EventManager.SceneStateChange -= ActivateInteraction;
    }

    private void CanDisplayText(bool textStatus)
    {
        textRequested = textStatus;
    }

    private void ActivateInteraction(SceneStateType sceneStateType)
    {
        if (textActiveScene == sceneStateType)
            interactionActive = true;
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
            textRequested = !textRequested;
        }
    }

    private void ChangeHighlight(bool highlightActive)
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
