using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractRecordPlayer : MonoBehaviour
{
    public GameObject RecordPlayer;
    public GameObject text;
    bool puzzleReady;
    public DialogueManager dialogueManager;
     void Start()
    {
        text.SetActive(false);
        puzzleReady = false;
    }
    private void Update()
    {
        if (puzzleReady == true && Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.StartRecordPuzzle();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == RecordPlayer)
        {
            text.SetActive(true);
            puzzleReady = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == RecordPlayer)
        {
            text.SetActive(false);
            puzzleReady = false;
            dialogueManager.StopRecordPuzzle();
        }
    }
}
