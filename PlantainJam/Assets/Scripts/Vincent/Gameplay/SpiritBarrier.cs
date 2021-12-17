using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpiritBarrier : MonoBehaviour
    {
        [SerializeField] private GameObject visuals;
        [SerializeField] private BoxCollider2D collider;

        public void Awake()
        {
            collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }
        
        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldTypeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldTypeChanged;
        }
        
        private void WorldTypeChanged(WorldMode worldMode)
        {
            if (worldMode == WorldMode.SpiritWorld)
            {
                visuals.SetActive(true);
                collider.enabled = true;
            }
            else
            {
                visuals.SetActive(false);
                collider.enabled = false;
            }
        }

    }
}