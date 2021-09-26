using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameDirector : MonoBehaviour
    {
        public enum WorldMode { RealWorld, SpiritWorld }

        public void Start()
        {
            EventManager.OnWorldTypeChanged(WorldMode.RealWorld);
        }
    }
}