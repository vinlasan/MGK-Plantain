using System.Collections;
using UnityEngine;

namespace Ghost
{
    [RequireComponent(typeof(GhostMovement))]
    public class StateController : MonoBehaviour
    {
        [SerializeField]
        private BaseState currentState, previousState;

        public GhostMovement ghostMovement { get; set; }

        private static BaseState defaultState;

        [SerializeField]
        private float calculationTime;

        private void Start()
        {
            ghostMovement = GetComponent<GhostMovement>();
            currentState.InitializeState(this);
            StartCoroutine(UpdateStates());
        }

        private void LateUpdate()
        {
            
        }

        public void ChangeState(BaseState newState)
        {
            previousState = currentState;
            currentState = newState;
            previousState.ExitState(this);
            currentState.InitializeState(this);
        }

        private IEnumerator UpdateStates()
		{
			currentState.UpdateState(this);
            yield return new WaitForSeconds(calculationTime);
            StartCoroutine(UpdateStates());
		}
    }

}
