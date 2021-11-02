using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpositionScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    
    //public TextMeshProUGUI textPrefab;
    //public GameObject image;
    public AudioSource cutsceneSFX;
    [SerializeField]
    private TextMeshProUGUI textObject;

    private void Start()
    {
        story = new Story(inkJSON.text);
        //textObject = Instantiate(textPrefab, image.transform, false) as TextMeshProUGUI;
        
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

        //eraseUI();

        //TextMeshPro storyText = Instantiate(textPrefab) as TextMeshPro;

        string text = loadStoryChunk();
        List<string> tags = story.currentTags;
        if (tags.Count > 0 && tags[0] != "#EndSceneGhostIntro")
        {
            text = tags[0] + " : " + text;
            if (tags[0] == "EndSceneGhostIntro")
            {
                SceneManager.LoadScene("RunToBody");
            }
            else if (tags[0] == "StartRecordPuzzle")
            {
                SceneManager.LoadScene("RecordPuzzleScene");
            }
        }
    
        //Debug.Log(storyText.text);
        textObject.text = text;
        cutsceneSFX.Play();
    }

    /*void eraseUI()
    {
        for (int i = 0; i < image.transform.childCount; i++)
        {
            Destroy(image.transform.GetChild(i).gameObject);
        }
    }*/

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
