using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [System.Serializable]
    public class AreaPointHolder 
    {
        public PatrolPoint[] points;

        public PatrolPoint.FloorLevel floorLevel;
    }
}