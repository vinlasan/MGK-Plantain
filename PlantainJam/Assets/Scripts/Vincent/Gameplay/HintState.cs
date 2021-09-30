namespace Gameplay
{
    //TODO Change these enum names these are strictly placeholder lol
    public enum HintType { Hint1, Hint2, Hint3, Hint4 }  
    public class HintState
    {
        public bool hintCollected;
        public HintType hintType;

        /// <summary>
        /// Creates a new Hint object to be used by the Director for tracking which hints are collected.
        /// </summary>
        /// <param name="hintType"></param>
        /// <param name="collected">Default is always true</param>
        public HintState(HintType hintType, bool collected = true)
        {
            this.hintType = hintType;
            hintCollected = collected;
        }
    }
}