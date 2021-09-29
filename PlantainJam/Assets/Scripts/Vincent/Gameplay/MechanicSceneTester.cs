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
        
        private Queue<Plantain> plantains;

        private void Start()
        {
            plantains = new Queue<Plantain>();
        }

        void Update()
        {
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
    }
}