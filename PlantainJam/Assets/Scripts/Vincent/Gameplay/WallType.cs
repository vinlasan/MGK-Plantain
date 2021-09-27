using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WallType : MonoBehaviour
    {
        public WorldMode wallColliderType;

        private bool spiritWorldTraverse;

        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Color realColor, spiritColor;

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
            spiritWorldTraverse = false;
            spriteRenderer = transform.parent.GetComponentInChildren<SpriteRenderer>();
        }

        private void WorldTypeChanged(WorldMode worldMode)
        {
            //if no plantain detected nearby toggle normally
            if (worldMode == WorldMode.SpiritWorld && spiritWorldTraverse)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                spriteRenderer.color = Color.grey;
                return;
            }

            if (worldMode != wallColliderType)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                if (worldMode == WorldMode.RealWorld)
                    spriteRenderer.color = realColor;
                else spriteRenderer.color = spiritColor;
            }
        }
        
        /*private void OnTriggerEnter2D(Collider2D col)
        {
            Plantain plantain = col.GetComponent<Plantain>();
            if (plantain != null && wallColliderType == WorldMode.SpiritWorld)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                spriteRenderer.color = Color.grey;
            }
        }*/

        public void EnableSpiritWorldTraverse()
        {
            //if(wallColliderType == WorldMode.SpiritWorld)
            Debug.Log("Plaintain encountered " + wallColliderType);
            spiritWorldTraverse = true;
        }

        public void DisableSpiritWorldTraverse()
        {
            spiritWorldTraverse = false;
        }
    }
}

