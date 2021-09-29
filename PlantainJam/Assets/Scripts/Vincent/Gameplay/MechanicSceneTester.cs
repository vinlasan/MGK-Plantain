using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Puzzle.Test
{
    public class MechanicSceneTester : MonoBehaviour
    {
        [SerializeField]
        private Plantain plantainPrefab;
        [SerializeField]
        private Transform playerLocation;

        private WorldMode worldMode;
        
        private Queue<Plantain> plantains;

        private void Awake()
        {
            plantains = new Queue<Plantain>();
            worldMode = WorldMode.RealWorld;
        }

        void Update()
        {
            DebugWorldSwitch();
            if (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.Q))
            {
                Plantain p = Instantiate(plantainPrefab, playerLocation.position, Quaternion.identity);
                plantains.Enqueue(p);
            }

            if (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.E))
            {
                if (plantains.Count > 0)
                {
                    Plantain p = plantains.Peek();
                    plantains.Dequeue();
                    Destroy(p.gameObject);
                }
            }
        }

        private void OnEnable()
        {
            EventManager.WorldTypeChange += WorldModeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= WorldModeChanged;
        }

        private void WorldModeChanged(WorldMode w)
        {
            worldMode = w;
        }

        private void DebugWorldSwitch()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if(worldMode == WorldMode.RealWorld)
                    EventManager.OnWorldTypeChanged(WorldMode.SpiritWorld);
                else EventManager.OnWorldTypeChanged(worldMode = WorldMode.RealWorld);
            }
        }
    }
}