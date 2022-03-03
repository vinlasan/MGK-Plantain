using UnityEngine;

namespace Gameplay.Puzzle
{
    public class ReturnToBody : MonoBehaviour
    {
        [SerializeField] private SceneStateType disableMovement, enableMovement, spiritWorld, realWorld;

        [SerializeField, Range(0.25f, 2)]
        private float transitionTime;

        [SerializeField, Range(2, 6)] 
        private int getOutOfBedDistance;
        
        [SerializeField] private GameObject effects;
        private bool transitioning;

        private void Awake()
        {
            transitioning = false;
        }

        private void OnEnable()
        {
            EventManager.WorldTypeChange += OnWorldTypeChanged;
        }

        private void OnDisable()
        {
            EventManager.WorldTypeChange -= OnWorldTypeChanged;
        }

        private void OnWorldTypeChanged(WorldMode mode)
        {
            if(mode == WorldMode.RealWorld)
                effects.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !LeanTween.isTweening(other.gameObject))
            {
                TransitionToOtherWorld(other.gameObject);
            }
        }

        private void TransitionToOtherWorld(GameObject playerObject)
        {
            transitioning = true;
            if (GameDirector.Instance.worldMode == WorldMode.SpiritWorld)
            {
                Debug.Log("Playing transition to bed at " + Time.timeSinceLevelLoad);
                EventManager.OnSceneStateChanged(disableMovement);
                EventManager.OnSceneStateChanged(realWorld);
                LeanTween.move(playerObject, transform.position, transitionTime);
                LeanTween.rotate(playerObject, transform.rotation.eulerAngles, transitionTime).setOnComplete(
                    () =>
                    {
                        effects.SetActive(false);
                        LeanTween.rotate(playerObject, Vector3.zero, 0.15f).setOnComplete(
                            ()=>
                            {
                                EventManager.OnSceneStateChanged(enableMovement);
                            });
                    });
            }
            else //real world to spirit world animation
            {
                Debug.Log("Playing transition from bed at " + Time.timeSinceLevelLoad);
                EventManager.OnSceneStateChanged(disableMovement);
                //go from the bed laying down, transition to the spirit world, then move to the foot of the bed
                playerObject.transform.position = transform.position;
                playerObject.transform.rotation = transform.rotation;
                EventManager.OnSceneStateChanged(spiritWorld);
                Vector3 outOfBed = new Vector3(transform.position.x + getOutOfBedDistance, transform.position.y, transform.position.z);
                effects.SetActive(true);
                LeanTween.move(playerObject, outOfBed, transitionTime);
                LeanTween.rotate(playerObject, Vector3.zero, transitionTime).setOnComplete(
                    () =>
                    {
                        EventManager.OnSceneStateChanged(enableMovement);
                    });
            }
        }
    }
}