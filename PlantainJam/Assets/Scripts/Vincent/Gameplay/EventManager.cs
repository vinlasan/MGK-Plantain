using AudioUtilities;

namespace Gameplay
{
    public static class EventManager
    {
        public delegate void GameEvent();
        public delegate void GameEvent<T>(T obj);

        public static event GameEvent<WorldMode> WorldTypeChange;
        public static event GameEvent<bool> DebugMode;

        public static void OnWorldTypeChanged(WorldMode worldMode)
        {
            if (WorldTypeChange != null)
                WorldTypeChange(worldMode);
        }

        public static void OnDebugMode(bool enabled)
        {
            if (DebugMode != null)
                DebugMode(enabled);
        }
    }
}