using UnityEngine;

namespace Ghost
{
    public abstract class BaseState : ScriptableObject
    {
        [SerializeField]
        public Transition[] transitions;

        public abstract void InitializeState(StateController controller);
        public virtual void UpdateState(StateController controller)
        {
            CheckTransitions(controller);
        }
        public virtual void ExitState(StateController controller){ }
        public virtual void MovementUpdate(StateController controller){}
        protected void CheckTransitions(StateController controller)
        {
            foreach (Transition tran in transitions)
            {
                bool decisionResult = tran.decision.MakeDecision(tran.decisionChoice, controller);
                if (decisionResult)
                {
                    controller.ChangeState(tran.trueState);
                }
            }
        }
    }
}