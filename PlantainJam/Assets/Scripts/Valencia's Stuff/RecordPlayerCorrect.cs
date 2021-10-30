using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerCorrect : MonoBehaviour
{
    public AudioChoice audioChoice;
    public GameObject RecordPuzzleDialogue;
    public GameObject RecordPuzzleRight;
   public void RightChoice()
    {
        if (audioChoice.correct == true)
        {
            
            RecordPuzzleDialogue.SetActive(false);
            RecordPuzzleRight.SetActive(true);
        }
    }

    
}
