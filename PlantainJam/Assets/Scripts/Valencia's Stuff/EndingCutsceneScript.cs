using Ink.Runtime;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCutsceneScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;

    public AudioSource cutsceneSFX;
    [SerializeField]
    private TextMeshProUGUI textObject;

    [SerializeField]
    private SceneStateType dialogueEnd;

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

        string text = loadStoryChunk();
        List<string> tags = story.currentTags;

        //check tags to determine when to transition to next scene according to inkle story
        /*
        if (tags.Count > 0 && tags[0] != "#EndSceneGhostIntro")
        {
            if (tags[0] == "EndSceneGhostIntro")
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        */

        //Debug.Log(storyText.text);
        textObject.text = text;
        cutsceneSFX.Play();
    }


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
