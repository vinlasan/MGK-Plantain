using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ErrorCount : MonoBehaviour
{
    public Text errorText;
    public int errorCount;
    public GameObject RecordPuzzleDialogue;
    public GameObject RecordPuzzleWrong;
    public GameObject RecordPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        errorCount = 0;
        errorText.text = "Error Count: " + errorCount;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (errorCount == 3)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

   public void increaseErrrorCount()
    {
        errorCount++;
        errorText.text = "Error Count: " + errorCount;
        DontDestroyOnLoad(GameObject.Find("ErrorManager"));
        RecordPuzzleDialogue.SetActive(false);
        RecordPuzzleWrong.SetActive(true);

    }

   public void ResetPuzzle()
    {
        RecordPuzzleDialogue.SetActive(false);
        RecordPuzzleWrong.SetActive(false);
        
    }
}
