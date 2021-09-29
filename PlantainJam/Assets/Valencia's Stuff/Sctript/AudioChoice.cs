using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChoice : MonoBehaviour
{
    public RecordPuzzle recordPuzzle;
    public AudioSource piano;
    public AudioSource jazz;
    public AudioSource dig;
    public AudioSource organ;
    public AudioSource country;
    public bool correct;
    public ErrorCount errorScript;

    public void PlayAudio()
    {
        switch (recordPuzzle.playerChoiceText)
        {
            case "Piano":
                Debug.Log("Playing Piano");
                if (jazz.isPlaying || dig.isPlaying || organ.isPlaying || country.isPlaying)
                {
                    jazz.Stop();
                    dig.Stop();
                    organ.Stop();
                    country.Stop();
                }
                piano.Play();
                break;
            case "Jazz":
                Debug.Log("Playing Jazz");
                if (piano.isPlaying || dig.isPlaying || organ.isPlaying || country.isPlaying)
                {
                    piano.Stop();
                    dig.Stop();
                    organ.Stop();
                    country.Stop();
                }
                jazz.Play();
                break;
            case "Dig":
                Debug.Log("Playing Dig");
                if (jazz.isPlaying || piano.isPlaying || organ.isPlaying || country.isPlaying)
                {
                    jazz.Stop();
                    piano.Stop();
                    organ.Stop();
                    country.Stop();
                }
                dig.Play();
                break;
            case "Organ":
                Debug.Log("Playing Organ");
                if (jazz.isPlaying || dig.isPlaying || piano.isPlaying || country.isPlaying)
                {
                    jazz.Stop();
                    dig.Stop();
                    piano.Stop();
                    country.Stop();
                }
                organ.Play();
                break;
            case "Country":
                Debug.Log("Playing Country");
                if (jazz.isPlaying || dig.isPlaying || organ.isPlaying || piano.isPlaying)
                {
                    jazz.Stop();
                    dig.Stop();
                    organ.Stop();
                    piano.Stop();
                }
                country.Play();
                break;
            case "No":
                Debug.Log("Player choose No");
                piano.Stop();
                jazz.Stop();
                dig.Stop();
                organ.Stop();
                country.Stop();
                recordPuzzle.ResetStory();
            break;
            case "Yes":
                if (jazz.isPlaying)
                {
                    Debug.Log("Correct Choice");
                    correct = true;
                }
                else if (piano.isPlaying || dig.isPlaying || organ.isPlaying || country.isPlaying)
                {
                    Debug.Log("Wrong Choice");
                    correct = false;
                    errorScript.increaseErrrorCount();
                    recordPuzzle.ResetStory();
                }
                break;
        }
       
    }
}
