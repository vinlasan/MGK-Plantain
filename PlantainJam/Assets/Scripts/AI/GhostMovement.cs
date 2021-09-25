using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Ghost.Pathfinding;

namespace Ghost
{
    [RequireComponent(typeof(AIPath))]
    public class GhostMovement : MonoBehaviour
    {
        private AIPath pather;
        private PatrolPoint startingPoint;
        private PatrolPoint[] path;

        [SerializeField]
        private float disractionRadius;
        private int pathIndex;

        public bool endOfPath { get; private set; }

        private void Start()
        {
            pather = GetComponent<AIPath>();
        }

        private void OnEnable()
        {
            GhostEvents.EndOfPathReached += EndOfPathReached;
        }

        private void OnDisable()
        {
            GhostEvents.EndOfPathReached -= EndOfPathReached;
        }

        private void EndOfPathReached()
        {
            endOfPath = true;
        }

        public void SetPath(PatrolPoint[] p)
        {
            path = p;
            pathIndex = 0;
            pather.destination = path[pathIndex].location;
        }

        public bool EndofPathReached()
        {
            return pather.reachedEndOfPath;
        }

        public bool SetNextPoint()
        {
            Debug.LogWarning("End of path reached, moving to next path");
            if (pathIndex < path.Length - 1)
            {
                Debug.LogWarning("Next path index is " + pathIndex);
                pathIndex++;
                pather.destination = path[pathIndex].location;
                return true;
            }
            else pathIndex = 0;
            return false;
        }

        public void StartMovement()
        {
            pather.canMove = true;
            pather.canSearch = true;
        }

        public void StopMovement()
        {
            pather.canMove = false;
            pather.canSearch = false;
        }
    }
}