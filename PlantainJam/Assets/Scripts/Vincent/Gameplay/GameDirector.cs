using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public enum WorldMode { RealWorld, SpiritWorld }
    [DisallowMultipleComponent]
    public class GameDirector : MonoBehaviour
    {
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
        }

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldModeChanged;
            EventManager.HintCollected += HintAdded;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldModeChanged;
            EventManager.HintCollected -= HintAdded;
        }

        private void WorldModeChanged(WorldMode mode)
        {
            //Add any changes that need to happen during world transition here
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