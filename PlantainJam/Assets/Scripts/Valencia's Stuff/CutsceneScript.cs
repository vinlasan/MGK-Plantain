using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;


    public Text textPrefab;
    public Image image;
    public AudioSource cutsceneSFX;

    public GameObject player;

    public ErrorCount errorCount;
  
    private void Start()
    {
        story = new Story(inkJSON.text);


        refreshUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            refreshUI();
            
        }
    }
    void refreshUI()
    {

        eraseUI();

        Text storyText = Instantiate(textPrefab) as Text;

        string text = loadStoryChunk();
        List<string> tags = story.currentTags;
      
        if (tags.Count > 0 && tags[0] != "EndScene" && tags[0] != "EndRightChoice")
        {
            text = tags[0] + " : " +text;
       
        }
        else if (tags[0] == "EndScene")
        {
            player.transform.position = new Vector3(-32f, -31f, -5f);
            story.ResetState();
            errorCount.ResetPuzzle();
        }
        else if (tags[0] == "EndRightChoice")
        {
            SceneManager.LoadScene("EndGame");
        }



        Debug.Log(storyText.text);
        storyText.text = text;
        cutsceneSFX.Play();
        storyText.transform.SetParent(image.transform, false);

       
    }

    void eraseUI()
    {
        for (int i = 0; i < image.transform.childCount; i++)
        {
            Destroy(image.transform.GetChild(i).gameObject);
        }
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {

            text = story.Continue();
            
            Debug.Log(text);
            
        }
      

        return text;
    }
}
