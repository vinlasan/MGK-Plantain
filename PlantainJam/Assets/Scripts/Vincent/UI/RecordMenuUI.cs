using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
using Gameplay.Puzzle;
using AudioUtilities;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecordMenuUI : MonoBehaviour
{


    [SerializeField]
    private SceneStateType PuzzleComplete;
    [SerializeField]
    private SceneStateType PuzzleFailed;

    // Start is called before the first frame update
    void Start()
    {
        //button.OnPointerEnter()
    }

    public void MouseOver(int optionNum)
    {
        switch(optionNum)
        {
            case 0:
                //PlayRecordAudio();
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(GameDirector.Instance.mixerController.option1);
                break;
            case 1:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(GameDirector.Instance.mixerController.option2);
                break;
            case 2:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(GameDirector.Instance.mixerController.option3);
                break;
            case 3:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(GameDirector.Instance.mixerController.option4);
                break;
            case 4:
               // EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(GameDirector.Instance.mixerController.option5);
                break;

        }
         

    }


    public void MouseExit(int optionNum)
    {
        
    }

    public void ButtonClicked(int optionNum)
    {
        if(optionNum == 0)
            EventManager.OnSceneStateChanged(PuzzleComplete);
        else if(optionNum >= 1)
            EventManager.OnSceneStateChanged(PuzzleFailed);
    }

        public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
