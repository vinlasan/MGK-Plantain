using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class WallSwitcher : MonoBehaviour
    {
        
        

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
            /*//if no plantain detected nearby toggle normally
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
            }*/
        }
    }
}