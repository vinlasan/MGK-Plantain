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

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldTypeChanged;
            EventManager.DebugMode += EnableDebugVisuals;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldTypeChanged;
            EventManager.DebugMode -= EnableDebugVisuals;
        }

        public void Awake()
        {
            spiritWorldTraverse = false;
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void EnableDebugVisuals(bool enabled)
        {
            debugVisuals = enabled;
            spriteRenderer.gameObject.SetActive(enabled);
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            //if no plantain detected nearby toggle normally
            if (worldMode == WorldMode.SpiritWorld && spiritWorldTraverse)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                if(debugVisuals)
                    spriteRenderer.color = Color.grey;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
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