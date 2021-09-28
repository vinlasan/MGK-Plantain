using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class SpiritBarrier : MonoBehaviour
    {
        private Transform visuals;

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldTypeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldTypeChanged;
        }

        public void Start()
        {
            visuals = GetComponentInChildren<Transform>();
        }
        
        private void WorldTypeChanged(WorldMode worldMode)
        {
            
            if (worldMode == WorldMode.SpiritWorld)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                visuals.gameObject.SetActive(true); 
            }
            else
            {
                visuals.gameObject.SetActive(false); 
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}