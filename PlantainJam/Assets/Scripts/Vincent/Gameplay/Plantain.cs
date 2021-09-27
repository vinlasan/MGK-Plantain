using System.Collections;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : MonoBehaviour
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
            //StartCoroutine(ResetTrigger());
        }
        
        private IEnumerator ResetTrigger()
        {
            GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForFixedUpdate();
            GetComponent<CircleCollider2D>().enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            /*WallType wall = col.GetComponent<WallType>();
            if(wall != null && wall.wallColliderType != WorldMode.SpiritWorld)
            {
                wall.EnableSpiritWorldTraverse();
            }*/
            //WallSwitcher wallSwitcher = col.GetComponent<WallSwitcher>();
            
            //if(wallSwitcher != null)
            //    wallSwitcher.EnableSpiritWorldTraverse();
            
            if(col.TryGetComponent(out WallSwitcher wall))
            {
                wall.EnableSpiritWorldTraverse();
            }
        }
        
        

        /*private void OnTriggerStay2D(Collider2D col)
        {
            WallType wall = col.GetComponent<WallType>();
            if (wall != null)
            {
                wall.EnableSpiritWorldTraverse();
            }
        }*/

        private void OnTriggerExit2D(Collider2D col)
        {
            /*WallType wall = col.GetComponent<WallType>();
            if(wall != null)
            {
                wall.DisableSpiritWorldTraverse();
            }*/
            
            if(col.TryGetComponent(out WallSwitcher wall))
            {
                wall.DisableSpiritWorldTraverse();
            }
        }
    }
}