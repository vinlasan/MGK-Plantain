namespace Ghost
{
    public static class GhostEvents 
    {
        public delegate void GhostEvent();
        public delegate void GhostEvent<T>(T obj);

        public static event GhostEvent EndOfPathReached;

        public static void OnEndOfPathReached()
        {
            if(EndOfPathReached != null)
                EndOfPathReached();
        }
    }
}