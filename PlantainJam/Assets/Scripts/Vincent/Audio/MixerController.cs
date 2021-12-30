using System.Collections;
using Gameplay;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioUtilities
{
    public class MixerController : MonoBehaviour
    {
        //public static MixerController Instance { get; private set; }

        public enum MusicLevels { LimboNormal = -2, PhysicalNormal = 0, PhysicalMute = -80, LimboMute = -80}
        [SerializeField]
        private AudioMixer mixer;
        
        [SerializeField]
        private AudioMixerSnapshot limboSnapshot, physicalSnapShot, bgmMutedSnapshot;

        [SerializeField] 
        private AudioSource limboMusic, physicalMusic;

        public AudioSource option1;
        public AudioSource option2;
        public AudioSource option3;
        public AudioSource option4;
        public AudioSource option5;

        private bool puzzleMusicPlaying;

        private AudioSource currentPlayingMusicTrack;

        private WorldMode worldMode;
        
        private const string physicalMixerVolume = "PhysVolume", limboMixerVolume = "LimboVolume";

        private void Start()
        {
            //Instance = this;
            puzzleMusicPlaying = false;
            StartBGM();
            //bgmMusicGroup.audioMixer.SetFloat("Volume", 10);
        }

        private void OnEnable()
        {
            EventManager.AudioPlayRecordMusic += PlayRecordAudio;
            EventManager.GameStart += StartBGM;
            EventManager.WorldTypeChange += SwitchSnapshots;
            EventManager.AudioStopRecordMusic += StopRecordAudio;
        }

        private void OnDisable()
        {
            EventManager.AudioPlayRecordMusic -= PlayRecordAudio;
            EventManager.GameStart -= StartBGM;
            EventManager.WorldTypeChange -= SwitchSnapshots;
            EventManager.AudioStopRecordMusic -= StopRecordAudio;
        }

        private void StartBGM()
        {
            physicalMusic.Play();
            limboMusic.Play();
        }

        private void StopBGM()
        {
            limboMusic.Stop();
            physicalMusic.Stop();
        }

        private void SwitchSnapshots(WorldMode wMode)
        {
            worldMode = wMode;
            if(worldMode == WorldMode.RealWorld)
                physicalSnapShot.TransitionTo(1.0f);
            else limboSnapshot.TransitionTo(1.0f);
        }

        private void ChangeBGMVolume(AudioSource bgm, float level)
        {
            if (bgm == limboMusic)
                mixer.SetFloat(limboMixerVolume, level);
            else if (bgm == physicalMusic)
                mixer.SetFloat(physicalMixerVolume, level);
        }

        private void ToggleBGM(bool mute = false)
        {
            if(mute)
                bgmMutedSnapshot.TransitionTo(1);
            else SwitchSnapshots(worldMode);
        }
        
        //private IEnumerator TransitionBackToBGM(float tranistionRate, )

        private void PlayRecordAudio(AudioSource audioSource)
        {
            //mute the background music
            //ChangeBGMVolume(limboMusic, (float)MusicLevels.LimboMute);
            //ChangeBGMVolume(physicalMusic, (float)MusicLevels.PhysicalMute);
            ToggleBGM(true);
            
            if (!audioSource.isPlaying)
            {
                if(currentPlayingMusicTrack != null && currentPlayingMusicTrack.isPlaying)
                    currentPlayingMusicTrack.Stop();
                audioSource.Play();
                currentPlayingMusicTrack = audioSource;
            }
        }

        private void StopRecordAudio()
        {
            if(currentPlayingMusicTrack != null)
                currentPlayingMusicTrack.Stop();
            
            if (worldMode == WorldMode.RealWorld)
            {
                if (!physicalMusic.isPlaying)
                    physicalMusic.Play();
                ToggleBGM();
                //ChangeBGMVolume(physicalMusic, (float)MusicLevels.PhysicalNormal);
            }
            else
            {
                if(!limboMusic.isPlaying)
                    limboMusic.Play();
                ToggleBGM();
                //ChangeBGMVolume(limboMusic, (float)MusicLevels.LimboNormal);
            }
        }

        private IEnumerator GhostApproachDuration(float duration)
        {
            yield return new WaitForSeconds(duration);
            //TODO disable the filter after the duration
        }
    }
}
