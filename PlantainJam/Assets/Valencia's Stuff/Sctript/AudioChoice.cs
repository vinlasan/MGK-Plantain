using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChoice : MonoBehaviour
{
    public TestInkScript testInk;
    public AudioSource piano;
    public AudioSource jazz;
    public AudioSource dig;
    public AudioSource organ;
    public AudioSource country;


    public void PlayAudio()
    {
        switch (testInk.playerChoiceText)
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

        }
       
    }
}
