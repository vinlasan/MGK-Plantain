using AudioUtilities;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Gameplay
{
    public static class EventManager
    {
        public delegate void GameEvent();
        public delegate void GameEvent<T>(T obj);
        public delegate void GameEvent<T1, T2>(T1 obj1, T2 obj2);

        public static event GameEvent<WorldMode> WorldTypeChange;
        public static event GameEvent<bool> DebugMode;
        /// <summary>
        /// Only to be listened to by the Game Director for storing what hints are collected.
        /// </summary>
        public static event GameEvent<bool> TogglePlayerMovement;

        public static event GameEvent<AudioSource> AudioPlayRecordMusic;
        public static event GameEvent AudioStopRecordMusic;
        public static event GameEvent<float> AudioGhostApproach;
        public static event GameEvent GameStart;
        public static event GameEvent SwitchWorldType;

        public static void OnWorldTypeChanged(WorldMode worldMode)
        {
            if (WorldTypeChange != null)
                WorldTypeChange(worldMode);
        }

        public static void OnDebugMode(bool enabled)
        {
            if (DebugMode != null)
                DebugMode(enabled);
        }
        
        public static void OnTogglePlayerMovement(bool shouldMove)
        {
            if (TogglePlayerMovement != null)
                TogglePlayerMovement(shouldMove);
        }

        public static void OnAudioPlayRecordMusic(AudioSource clip)
        {
            if (AudioPlayRecordMusic != null)
                AudioPlayRecordMusic(clip);
        }

        public static void OnAudioStopRecordMusic()
        {
            if (AudioStopRecordMusic != null)
                AudioStopRecordMusic();
        }

        public static void OnAudioGhostApproach(float duration)
        {
            if (AudioGhostApproach != null)
                AudioGhostApproach(duration);
        }

        public static void OnGameStart()
        {
            if (GameStart != null)
                GameStart();
        }

        public static void OnSwitchWorldType()
        {
            if (SwitchWorldType != null)
                SwitchWorldType();
        }
    }
}