namespace AI
{
    public class Transition
    {
        public enum TransitionPriority {High, Medium, Low}
        public DecisionMaker decision = new DecisionMaker();
        public DecisionMaker.DecisionName decisionChoice;
        public TransitionPriority priorityLevel;
        public BaseState trueState;
    }
}