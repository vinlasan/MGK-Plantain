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
        private bool plantainChipActive;

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
            plantainChipActive = false;
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            
            if (worldMode == WorldMode.SpiritWorld && plantainChipActive == false)
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

        //check for collision with plantain chip
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "SpiritWall")
            {
                plantainChipActive = true;
                collider.enabled = false;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "SpiritWall")
            {
                plantainChipActive = false;
            }
        }

    }
}