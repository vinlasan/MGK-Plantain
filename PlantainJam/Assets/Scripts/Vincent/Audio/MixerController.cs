using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioUtilities
{
    public enum MusicGroups { }
    public class MixerController : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer mixer;

        [SerializeField] private AudioMixerGroup bgmMusicGroup;
        
        

        private void Start()
        {
            bgmMusicGroup.audioMixer.SetFloat("Volume", 0);
        }

        private void StartBGM()
        {
            
        }

        private void ChangeAudio()
        {
            
        }
    }
}
