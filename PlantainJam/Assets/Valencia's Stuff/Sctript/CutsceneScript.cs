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
        storyText.text = loadStoryChunk();
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