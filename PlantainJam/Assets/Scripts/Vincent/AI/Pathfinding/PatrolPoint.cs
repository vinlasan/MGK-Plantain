using UnityEngine;

namespace Ghost.Pathfinding
{
    public class PatrolPoint : MonoBehaviour
    {
        public enum FloorLevel { FirstFloor, SecondFloor }

        public FloorLevel patrolFloor;

        public float pathOrder;

        public Vector2 location { get { return (Vector2)this.gameObject.transform.position; } }
    }
}