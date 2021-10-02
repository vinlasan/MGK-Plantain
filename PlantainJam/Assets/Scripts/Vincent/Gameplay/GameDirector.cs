using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Gameplay
{
    public enum WorldMode { RealWorld, SpiritWorld }
    [DisallowMultipleComponent]
    public class GameDirector : MonoBehaviour
    {
        public GameObject limboEffects;
        public WorldMode worldMode { get; private set; }
        
        [SerializeField]
        private bool enableDebugModeOnStart;

        private List<HintState> CollectedHints;

        public static GameDirector Instance { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            CollectedHints = new List<HintState>();
            Instance = this;
        }
        
        private void Start()
        {
            worldMode = WorldMode.RealWorld;
            EventManager.OnWorldTypeChanged(worldMode);
            if (enableDebugModeOnStart)
                EventManager.OnDebugMode(true);
            else EventManager.OnDebugMode(false);
            if (limboEffects != null)
                limboEffects.SetActive(false);
        }

        private void OnEnable()
        {
            EventManager.HintCollected += HintAdded;
            EventManager.SwitchWorldType += ToggleWorldType;
        }

        private void OnDisable()
        {
            EventManager.HintCollected -= HintAdded;
            EventManager.SwitchWorldType -= ToggleWorldType;
        }

        private void ToggleWorldType()
        {
            if (worldMode == WorldMode.RealWorld)
            {
                worldMode = WorldMode.SpiritWorld;
                EventManager.OnWorldTypeChanged(worldMode);
                if (limboEffects != null)
                    limboEffects.SetActive(true);
            }
            else
            {
                worldMode = WorldMode.RealWorld;
                EventManager.OnWorldTypeChanged(worldMode);
                if (limboEffects != null)
                    limboEffects.SetActive(false); 
            }
        }

        private void HintAdded(HintState hint)
        {
            CollectedHints.Add(hint);
        }

        /// <summary>
        /// Checks if the HintType is recorded in the collection
        /// </summary>
        /// <param name="hintType"></param>
        public bool WasHintCollected(HintType hintType)
        {
            foreach (HintState hState in CollectedHints)
            {
                if (hState.hintType == hintType)
                    return true;
            }
            return false;
        }
    }
}