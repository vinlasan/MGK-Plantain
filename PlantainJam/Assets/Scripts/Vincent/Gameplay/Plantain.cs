using System;
using UnityEngine;

namespace Gameplay.Puzzle
{
    public class Plantain : Interactable 
    {
        public bool pickedUp { get; private set; }

        [SerializeField] private ParticleSystem wallParticleSystem;

        private Vector3 originalScale;
        private float wallCount = 0;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            EventManager.WorldTypeChange += OnWorldChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            EventManager.WorldTypeChange -= OnWorldChanged;
        }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (GameDirector.Instance.worldMode == WorldMode.RealWorld)
            {
                base.OnTriggerEnter2D(col);
                if(col.CompareTag("Player"))
                    EventManager.OnInteractableInRange(this, true);
            }
            if (col.TryGetComponent(out WallSwitcher wall))
            {
                wallCount++;
                wall.EnableSpiritWorldTraverse();
                wallParticleSystem.transform.localPosition = transform.InverseTransformPoint(wall.transform.position);
            }       
        }
        
        protected override void OnTriggerExit2D(Collider2D col)
        {
            base.OnTriggerExit2D(col);
            if(col.CompareTag("Player"))
                EventManager.OnInteractableInRange(this, false);

            if (GameDirector.Instance.worldMode == WorldMode.SpiritWorld)
                return;
            
            if(col.TryGetComponent(out WallSwitcher wall))
            {
                wallCount--;
                wallCount = wallCount < 0 ? 0 : wallCount;
                wall.DisableSpiritWorldTraverse();
            }
        }

        private void OnWorldChanged(WorldMode worldMode)
        {
            if(wallCount > 0 && worldMode == WorldMode.SpiritWorld)
            {
                wallParticleSystem.gameObject.SetActive(true);
                wallParticleSystem.Play();
            }
            else
            {
                wallParticleSystem.Stop();
                wallParticleSystem.gameObject.SetActive(false);
            }
        }

        public void Pickup(Vector3 playerLocation)
        {
            pickedUp = true;

            //play sound
            PerformAnimation(playerLocation, Vector3.zero, 0, 0.75f, false);
        }

        private void PerformAnimation(Vector3 toLocation, Vector3 scale, float alpha, float time, bool setActive)
        {
            LeanTween.cancel(gameObject);
            if (setActive)
            {
                gameObject.transform.position = toLocation;
                gameObject.SetActive(true);
            }
            else
            {
                LeanTween.move(gameObject, toLocation, time).setOnComplete(()=>gameObject.SetActive(setActive));
            }
            
            LeanTween.alpha(gameObject, alpha, time);
            LeanTween.scale(gameObject, scale, time);
        }

        public void Place(Vector3 position)
        {
            PerformAnimation(position, originalScale,1, 0.25f, true);
            pickedUp = false;
        }
    }
}