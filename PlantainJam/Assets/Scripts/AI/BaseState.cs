using UnityEngine;

namespace AI
{
    public abstract class BaseState : ScriptableObject
    {
        public Transition[] transitions;

        public abstract void InitializeState(StateController controller);
        public virtual void UpdateState(StateController controller){}
        public virtual void ExitState(StateController controller)
        {
            //darkController.ClearCooldowns();
        }
        public virtual void MovementUpdate(StateController controller){}
        protected virtual void CooldownCallback(StateController controller) {}
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