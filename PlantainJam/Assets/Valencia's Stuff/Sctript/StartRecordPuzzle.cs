using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class StartRecordPuzzle : MonoBehaviour
{
    Collider2D playerCollider;
    Collider2D ghostCollider;
    public GameObject dialogueBox;
    public GameObject Limbo;


    // Start is called before the first frame update
    void Start()
    {

        dialogueBox.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueBox.SetActive(true);
        }
    }

}
