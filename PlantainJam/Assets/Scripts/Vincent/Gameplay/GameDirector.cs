using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public enum WorldMode { RealWorld, SpiritWorld }
    public class GameDirector : MonoBehaviour
    {
        public WorldMode worldMode { get; private set; }
        
        [SerializeField]
        private bool enableDebugModeOnStart;
        
        public void Start()
        {
            worldMode = WorldMode.RealWorld;
            EventManager.OnWorldTypeChanged(worldMode);
            if(enableDebugModeOnStart)
                EventManager.OnDebugMode(true);
        }

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldModeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldModeChanged;
        }

        private void Update()
        {
            DebugWorldSwitch();
        }

#if UNITY_EDITOR
        private void DebugWorldSwitch()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if(worldMode == WorldMode.RealWorld)
                    EventManager.OnWorldTypeChanged(worldMode = WorldMode.SpiritWorld);
                else EventManager.OnWorldTypeChanged(worldMode = WorldMode.RealWorld);
            }
        }
#endif

        public void WorldModeChanged(WorldMode mode)
        {
            //Debug.Log("World mode changed to " + worldMode);
        }
    }
}