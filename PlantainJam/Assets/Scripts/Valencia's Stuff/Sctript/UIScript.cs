using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public void QuitGame()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("QUit Game");
        }
        else
        {
            Application.Quit();

        }

    }
}
