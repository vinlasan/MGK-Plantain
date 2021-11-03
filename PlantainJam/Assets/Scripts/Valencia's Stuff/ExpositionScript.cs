using Ink.Runtime;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpositionScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    
    //public TextMeshProUGUI textPrefab;
    //public GameObject image;
    public AudioSource cutsceneSFX;
    //[SerializeField]
    //private TextMeshProUGUI textObject;

    [SerializeField] 
    private SceneStateType dialogueEnd;

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
                //GameDirector.OnSceneStateChanged(dialogueEnd);
                SceneManager.LoadScene("RunToBody");
            }
            else if (tags[0] == "StartRecordPuzzle")
            {
                //GameDirector.OnSceneStateChanged(dialogueEnd);
                SceneManager.LoadScene("RecordPuzzleScene");
            }
        }
    
        //Debug.Log(storyText.text);
        EventManager.OnUpdateTextBox(text);
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
        else GameDirector.OnSceneStateChanged(dialogueEnd);

        return text;
    }
}
