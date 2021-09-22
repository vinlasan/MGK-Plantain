using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class DecisionMaker 
    {
        public enum DecisionName { PlayerBodyFound, WayPointReached,  }
        private Dictionary<DecisionName, Func<StateController, bool>> Decisions;

        public DecisionMaker()
        {
            Decisions = new Dictionary<DecisionName, Func<StateController, bool>>();
            Decisions.Add(DecisionName.PlayerBodyFound, PlayerBodyFound);
            Decisions.Add(DecisionName.WayPointReached, WayPointReached);
        }

        public bool MakeDecision(DecisionName dName, StateController controller)
        {
            try
            {
                if (controller != null)
                    return Decisions[dName].Invoke(controller);
                else return false;
            }
            catch(KeyNotFoundException k)
            {
                Debug.LogError("Key not found in DarkDecisionMaker: " + dName.ToString() + "Resulting in this error " + k);
                return false;
            }
        }

        private bool PlayerBodyFound(StateController controller)
        {
            return false;
        }

        private bool WayPointReached(StateController controller)
        {
            return false;
        }
    }
}