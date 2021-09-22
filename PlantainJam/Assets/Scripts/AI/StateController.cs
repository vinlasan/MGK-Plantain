using UnityEngine;

namespace AI
{
    public class StateController : MonoBehaviour
    {
        private BaseState currentState, previousState;

        private static BaseState defaultState;


        public void ChangeState(BaseState newState)
        {

        }

        private void UpdateStates()
		{
			currentState.UpdateState(this);
		}
    }

}
