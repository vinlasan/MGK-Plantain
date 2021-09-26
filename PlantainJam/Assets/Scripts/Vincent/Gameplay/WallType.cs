using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

namespace Gameplay.Puzzle
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WallType : MonoBehaviour
    {
        [SerializeField]
        private GameDirector.WorldMode wallColliderType;


        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldTypeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldTypeChanged;
        }

        private void WorldTypeChanged(GameDirector.WorldMode worldMode)
        {
            //if no plantain detected nearby toggle normally
            if(worldMode != wallColliderType)
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            else gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

