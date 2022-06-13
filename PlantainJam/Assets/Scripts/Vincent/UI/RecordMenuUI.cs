using UnityEngine;
using Gameplay;
using UnityEngine.EventSystems;

public class RecordMenuUI : MonoBehaviour
{


    [SerializeField]
    private SceneStateType PuzzleComplete;
    [SerializeField]
    private SceneStateType PuzzleFailed;

    [SerializeField] private AudioSource option1, option2, option3, option4, option5;

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
                EventManager.OnAudioPlayRecordMusic(option1);
                break;
            case 1:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(option2);
                break;
            case 2:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(option3);
                break;
            case 3:
                //EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(option4);
                break;
            case 4:
               // EventManager.OnAudioStopRecordMusic();
                EventManager.OnAudioPlayRecordMusic(option5);
                break;

        }
         

    }


    public void MouseExit(int optionNum)
    {
        
    }

    /*public void ButtonClicked(int optionNum)
    {
        if(optionNum == 0)
            EventManager.OnSceneStateChanged(PuzzleComplete);
        else if(optionNum >= 1)
            EventManager.OnSceneStateChanged(PuzzleFailed);
    }*/

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
