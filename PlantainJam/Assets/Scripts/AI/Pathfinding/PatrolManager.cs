using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI
{
    public class PatrolManager : MonoBehaviour
    {
        public AreaPointHolder[] patrolPointAreas;
        private PatrolPoint[] allKnownPoints;

        // Start is called before the first frame update
        void Start()
        {
            AissginAllPoints();   
        }

        private void AissginAllPoints()
        {
            allKnownPoints = FindObjectsOfType<PatrolPoint>();

            foreach(AreaPointHolder aPH in patrolPointAreas)
            {
                aPH.points = AssignPointsInSceneToAreaHolders(aPH);
                if(aPH.points.Length > 0)
                    aPH.points = SortPatrolPointsByPathOrder(aPH.points);
                else Debug.LogError(String.Format("No points found matching level {0}", aPH.floorLevel));
            }
        }

        private PatrolPoint[] SortPatrolPointsByPathOrder(PatrolPoint[] points)
		{
			if(points.Length > 0)
				Array.Sort(points, (t1, t2) => t1.pathOrder.CompareTo(t2.pathOrder));
            return points;
		}

        public PatrolPoint[] AssignPointsInSceneToAreaHolders(AreaPointHolder aPH)
        {
            List<PatrolPoint> pointGroup = new List<PatrolPoint>();

            for(int i = 0; i < allKnownPoints.Length; i++)
            {
                if(aPH.floorLevel == allKnownPoints[i].patrolFloor)
                    pointGroup.Add(allKnownPoints[i]);
                
            }
            
            return pointGroup.ToArray();
        }

        public PatrolPoint GetNextPoint()
        {
            //TODO get the next point in the list
            return new PatrolPoint();
        }
    }
}