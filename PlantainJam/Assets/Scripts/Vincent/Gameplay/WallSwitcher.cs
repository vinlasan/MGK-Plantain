using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WallSwitcher : MonoBehaviour
    {
        [SerializeField]
        private bool spiritWorldTraverse, debugVisuals;

        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Color realColor, spiritColor;

        [SerializeField] 
        private BoxCollider2D boxCollider2D = default; 
        
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
            spiritWorldTraverse = false;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            //if no plantain detected nearby toggle normally
            if (worldMode == WorldMode.SpiritWorld && spiritWorldTraverse)
            {
                boxCollider2D.enabled = false;
                if(debugVisuals)
                    spriteRenderer.color = Color.grey;
            }
            else
            {
                boxCollider2D.enabled = true;
                if (debugVisuals)
                {
                    if (worldMode == WorldMode.RealWorld)
                        spriteRenderer.color = realColor;
                    else spriteRenderer.color = spiritColor;
                }
            }
        }
        
        public void EnableSpiritWorldTraverse()
        {
            //Debug.Log("Plantain encountered ");
            spiritWorldTraverse = true;
        }
        
        public void DisableSpiritWorldTraverse()
        {
            spiritWorldTraverse = false;
        }
    }
}