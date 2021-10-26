using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject introDialgue;
    public GameObject RecordPuzzleDialogue;
    // Start is called before the first frame update
    void Start()
    {
        introDialgue.SetActive(true);
        RecordPuzzleDialogue.SetActive(false);
    }

   public void StartRecordPuzzle()
    {
        RecordPuzzleDialogue.SetActive(true);
    }
   public void StopRecordPuzzle()
    {
        RecordPuzzleDialogue.SetActive(false);
    }
}
