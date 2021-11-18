using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpiritBarrier : MonoBehaviour
    {
        private GameObject visuals;
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
            visuals = GetComponentInChildren<GameObject>();
            collider = GetComponent<BoxCollider2D>();
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            /*if (worldMode == WorldMode.SpiritWorld)
            {
                collider.enabled = true;
                visuals.SetActive(true);
            }
            else
            {
                collider.enabled = false;
                visuals.SetActive(false);
            }*/
        }

    }
}