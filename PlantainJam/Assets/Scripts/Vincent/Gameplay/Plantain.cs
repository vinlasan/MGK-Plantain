using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            WallType wall = col.GetComponent<WallType>();
            if(wall != null)
            {
                wall.ToggleSpiritWorldTraverse();
            }
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            WallType wall = col.GetComponent<WallType>();
            if (wall != null)
            {
                wall.ToggleSpiritWorldTraverse();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            WallType wall = col.GetComponent<WallType>();
            if(wall != null)
            {
                wall.ToggleSpiritWorldTraverse();
            }
        }
    }
}