using UnityEngine;

namespace AI
{
    public class FollowPathState : BaseState
    {
        [SerializeField]
        private PatrolPoint startingPoint;

        public override void InitializeState(StateController controller)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState(StateController controller)
        {
            base.UpdateState(controller);
        }

        public override void ExitState(StateController controller)
        {
            base.ExitState(controller);
        }


    }
}