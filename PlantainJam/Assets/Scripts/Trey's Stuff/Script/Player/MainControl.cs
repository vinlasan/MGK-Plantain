using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    idle,
    interact,
    stagger,
    gameover,
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MainControl : MonoBehaviour
{
    public GameObject RestartMenu;
    //public GameObject walksfx;

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    //public FloatValue currentHealth;
    //public Notification healthSignal;
    //public VectorValue startingPoint;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    public Collider2D triggerVolLimbo;
    //public GameObject attacksfx;
    //public GameObject walksfx;

    // Start is called before the first frame update
    void Start()
    {
        //playerInventory.currentItem = null;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //animator.SetFloat("moveX", 0);
        //animator.SetFloat("moveY", -1);
        //transform.position = startingPoint.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        //checks if player is in an interaction
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
   
        //disable this in favor of the new bed trigger setup
        if (Input.GetKeyDown(KeyCode.F))
        {
           EventManager.OnSwitchWorldType();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            //set variable to allow Limbo switch
    }

    void OnTriggerExit2D(Collider2D other)
    {
            //set variable to allow Limbo switch
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
        //walksfx.SetActive(true);
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        //walksfx.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndGameTrigger")
        {
            SceneManager.LoadScene("EndCutscene");
        }
        if (collision.gameObject.tag == "body")
        {
            SceneManager.LoadScene("RecordPuzzleOpenScene");
        }
        if (collision.gameObject.tag == "locked")
        {
            SceneManager.LoadScene("BeforeGhostScene");
        }
    }
    
}