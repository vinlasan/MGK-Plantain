using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ErrorCount : MonoBehaviour
{
    public Text errorText;
    public int errorCount;

    // Start is called before the first frame update
    void Start()
    {
        errorCount = 0;
        errorText.text = "Error Count: " + errorCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            increaseErrrorCount();
        }

        if (errorCount == 3)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void increaseErrrorCount()
    {
        errorCount++;
        errorText.text = "Error Count: " + errorCount;
    }
}
