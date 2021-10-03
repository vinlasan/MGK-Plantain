using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpiritBarrier : MonoBehaviour
    {
        private SpriteRenderer visuals;
        [SerializeField]
        private GameObject visualsObj;
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
            visuals = GetComponentInChildren<SpriteRenderer>();
            collider = GetComponent<BoxCollider2D>();
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            
            if (worldMode == WorldMode.SpiritWorld)
            {
                collider.enabled = true;
                visuals.enabled = true;
                if(visualsObj != null)
                    visualsObj.SetActive(true);
            }
            else
            {
                collider.enabled = false;
                visuals.enabled = false;
                if(visualsObj != null)
                    visualsObj.SetActive(false);
            }
        }
    }
}