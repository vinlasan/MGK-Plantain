using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public enum WorldMode { RealWorld, SpiritWorld }
    public class GameDirector : MonoBehaviour
    {
        
        public void Start()
        {
            EventManager.OnWorldTypeChanged(WorldMode.RealWorld);
        }

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldModeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldModeChanged;
        }

        public void WorldModeChanged(WorldMode worldMode)
        {
            Debug.Log("World mode changed to " + worldMode);
        }
    }
}