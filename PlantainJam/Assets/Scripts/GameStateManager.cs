using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Game Menu Buttons
    /// </summary>
    /// 
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("OpeningCutscene");
    }

    //To DO: 
    //Set up script to set player into the right scene state after restart
    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
