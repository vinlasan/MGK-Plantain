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
    [SerializeField]
    private TextMeshProUGUI textObject;

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

        //check tags to determine when to transition to next scene according to inkle story
        if (tags.Count > 0 && tags[0] != "#EndSceneGhostIntro")
        {
            //text = tags[0] + " : " + text;
            if (tags[0] == "EndSceneGhostIntro")
            {
                //GameDirector.OnSceneStateChanged(dialogueEnd);
                SceneManager.LoadScene("MainScene");
            }
            else if (tags[0] == "StartRecordPuzzle")
            {
                //GameDirector.OnSceneStateChanged(dialogueEnd);
                //SceneManager.LoadScene("RecordPuzzleScene");
            }
            if (tags[0] == "EndGame")
            {
                Debug.Log("Game Finished!");
                //TODO load back to main menu
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

            //Debug.Log(text);

        }
        else EventManager.OnSceneStateChanged(dialogueEnd);

        return text;
    }
}
