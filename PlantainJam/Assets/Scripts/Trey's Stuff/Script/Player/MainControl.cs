using Gameplay;
using Gameplay.Puzzle;
using UnityEngine;
using System.Collections.Generic;

public enum PlayerState
{
    walk,
    idle,
    interact,
    stagger,
    gameover,
}

[RequireComponent(typeof(Rigidbody2D))]
public class MainControl : MonoBehaviour
{
    //public GameObject walksfx;

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    private bool movementEnabled = true;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    public Collider2D triggerVolLimbo;

    private Queue<Plantain> plantains = new Queue<Plantain>();
    private Plantain activePlantain;
    private Interactable interactableInRange;

    [SerializeField] SceneStateType movementEnabledState, movementDisabledState; 
    
    
    //private SceneStateType endCutscene, recordPuzzleOpenScene, beforeGhostScene;

    // Start is called before the first frame update
    void Start()
    {
        //playerInventory.currentItem = null;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        interactableInRange = null;
        activePlantain = null;
        //animator.SetFloat("moveX", 0);
        //animator.SetFloat("moveY", -1);
        //transform.position = startingPoint.initialValue;

    }

    private void OnEnable()
    {
        //EventManager.TogglePlayerMovement += ToggleMovement;
        EventManager.InteractableInRange += InteractableInRange;
        EventManager.SceneStateChange += SceneStateChanged;
    }

    private void OnDisable()
    {
        //EventManager.TogglePlayerMovement -= ToggleMovement;
        EventManager.InteractableInRange -= InteractableInRange;
        EventManager.SceneStateChange -= SceneStateChanged;
    }

    private void SceneStateChanged(SceneStateType state)
    {
        if (movementEnabledState == state)
            movementEnabled = true;
        else if (movementDisabledState == state)
            movementEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in an interaction
        if (movementEnabled)
        {
            if (currentState == PlayerState.interact)
            {
                return;
            }

            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (interactableInRange && !interactableInRange.textRequested)
                    interactableInRange.DisplayText();
                else
                {
                    if (GameDirector.Instance.worldMode == WorldMode.RealWorld)
                    {
                        if (activePlantain)
                        {
                            if (!activePlantain.pickedUp)
                            {
                                plantains.Enqueue(activePlantain);
                                activePlantain.Pickup(transform.position);
                            }
                        }
                        else
                        {
                            if (plantains.Count > 0)
                            {
                                plantains.Peek().Place(transform.forward * 2 + transform.position);
                                plantains.Dequeue();
                            }
                        }
                    }
                }
            }
            
        }
        //disable this in favor of the new bed trigger setup
        /*if (Input.GetKeyDown(KeyCode.F))
        {
           EventManager.OnSwitchWorldType();
        }*/
    }

    public void InteractableInRange(Interactable interactable, bool inRange)
    {
        if (interactable is Plantain)
        {
            Plantain plantain = (Plantain) interactable;
            if(inRange && plantain != activePlantain)
                activePlantain = plantain;
            else if (!inRange && plantain == activePlantain)
                activePlantain = null;
        }
        else
        {
            if (inRange)
                interactableInRange = interactable;
            else interactableInRange = null;
        }
    }

    private void ToggleMovement(bool canMove)
    {
        movementEnabled = canMove;
        animator.SetBool("moving", false);
        //Debug.Log("Movement set to :" + movementEnabled);
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("recieve", true);
                currentState = PlayerState.interact;
                receivedItem.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("recieve", false);
                currentState = PlayerState.idle;
                receivedItem.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            currentState = PlayerState.walk;
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void FixedUpdate()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }
    //Debug.Log(change);
    void MoveCharacter()
    {
        if(!movementEnabled) return;
        //walksfx.SetActive(true);
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        //walksfx.SetActive(false);
    }
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndGameTrigger")
        {
            SceneManager.LoadScene("EndCutscene");
            //GameDirector.OnSceneStateChanged(endCutscene);
        }
        if (collision.gameObject.CompareTag("body"))
        {
            SceneManager.LoadScene("RecordPuzzleOpenScene");
            //GameDirector.OnSceneStateChanged(recordPuzzleOpenScene);
        }
        if (collision.gameObject.CompareTag("locked"))
        {
            SceneManager.LoadScene("BeforeGhostScene");
            //GameDirector.OnSceneStateChanged(beforeGhostScene);
        }
    }*/
}
