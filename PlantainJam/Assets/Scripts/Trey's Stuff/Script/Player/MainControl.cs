using System;
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

    private bool movementEnabled = true;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    public Collider2D triggerVolLimbo;

    [SerializeField]
    private SceneStateType endCutscene, recordPuzzleOpenScene, beforeGhostScene;

    // Start is called before the first frame update
    void Start()
    {
        //playerInventory.currentItem = null;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        if(!endCutscene || !recordPuzzleOpenScene || !beforeGhostScene)
            Debug.LogError("Assign the scene states for " + this.gameObject.name);
        //animator.SetFloat("moveX", 0);
        //animator.SetFloat("moveY", -1);
        //transform.position = startingPoint.initialValue;

    }

    private void OnEnable()
    {
        EventManager.TogglePlayerMovement += ToggleMovement;
    }

    private void OnDisable()
    {
        EventManager.TogglePlayerMovement -= ToggleMovement;
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
        }
        //disable this in favor of the new bed trigger setup
        /*if (Input.GetKeyDown(KeyCode.F))
        {
           EventManager.OnSwitchWorldType();
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            //set variable to allow Limbo switch
    }

    void OnTriggerExit2D(Collider2D other)
    {
            //set variable to allow Limbo switch
    }

    private void ToggleMovement(bool canMove)
    {
        movementEnabled = canMove;
        Debug.Log("Movement set to :" + movementEnabled);
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EndGameTrigger")
        {
            //SceneManager.LoadScene("EndCutscene");
            GameDirector.OnSceneStateChanged(endCutscene);
        }
        if (collision.gameObject.CompareTag("body"))
        {
            //SceneManager.LoadScene("RecordPuzzleOpenScene");
            GameDirector.OnSceneStateChanged(recordPuzzleOpenScene);
        }
        if (collision.gameObject.CompareTag("locked"))
        {
            //SceneManager.LoadScene("BeforeGhostScene");
            GameDirector.OnSceneStateChanged(beforeGhostScene);
        }
    }
    
}
