using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExpositionScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;


    public Text textPrefab;
    public Image image;
    public AudioSource cutsceneSFX;
    public AudioSource screamSFX;

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
        if (tags.Count > 0)
        {
            text = tags[0] + " : " + text;
            if (tags[0] == "Aya")
            {
                screamSFX.Play();
            }
            if (tags[0] == "EndSceneGhostIntro")
            {
                SceneManager.LoadScene("RunToBody");
            }
            else if (tags[0] == "StartRecordPuzzle")
            {
                SceneManager.LoadScene("RecordPuzzleScene");
            }
            else if (tags[0] == "EndOpenScene")
            {
                SceneManager.LoadScene("GoToAya");
            }
            else if (tags[0] == "BeforeGhostScene")
            {
                SceneManager.LoadScene("GhostIntro");
            }
            else if (tags[0] == "EndOpening")
            {
                SceneManager.LoadScene("OpeningScene"); 
            }
            else if (tags[0] == "EndGame")
            {
                Application.Quit();
            }

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
