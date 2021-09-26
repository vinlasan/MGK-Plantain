using UnityEngine;
using Ghost.Pathfinding;

namespace Ghost
{
    [CreateAssetMenu(menuName = "States/Follow")]
    public class FollowPathState : BaseState
    {
        [SerializeField]
        private PatrolPoint startingPoint;
        private PatrolPoint.FloorLevel floorLevel;

        public override void InitializeState(StateController controller)
        {
            controller.ghostMovement.StartMovement();
            controller.ghostMovement.SetPath(PatrolManager.Instance.GetPatrolPoints(floorLevel));
        }

        public override void UpdateState(StateController controller)
        {
            if (controller.ghostMovement.EndofPathReached())
            {
                controller.ghostMovement.SetNextPoint();
            }   
        }

        public override void ExitState(StateController controller)
        {
            base.ExitState(controller);
        }
    }
}