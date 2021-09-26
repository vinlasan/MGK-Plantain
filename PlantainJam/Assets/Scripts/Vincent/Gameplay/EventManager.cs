using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public static class EventManager
    {
        public delegate void GameEvent();
        public delegate void GameEvent<T>(T obj);

        public static event GameEvent<GameDirector.WorldMode> WorldTypeChange;

        public static void OnWorldTypeChanged(GameDirector.WorldMode worldMode)
        {
            if (WorldTypeChange != null)
                WorldTypeChange(worldMode);
        }
    }
}