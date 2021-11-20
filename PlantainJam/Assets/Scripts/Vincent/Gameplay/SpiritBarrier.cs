using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpiritBarrier : MonoBehaviour
    {
        private Transform visuals;
        private BoxCollider2D collider;

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldTypeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldTypeChanged;
        }

        public void Awake()
        {
            visuals = GetComponentInChildren<Transform>();
            collider = GetComponent<BoxCollider2D>();
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            if (worldMode == WorldMode.SpiritWorld)
            {
                collider.enabled = true;
                visuals.gameObject.SetActive(true);
            }
            else
            {
                collider.enabled = false;
                visuals.gameObject.SetActive(false);
            }
        }

    }
}