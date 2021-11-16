using UnityEngine;
using System.Collections.Generic;

namespace Gameplay
{
    public enum WorldMode { RealWorld, SpiritWorld }
    [DisallowMultipleComponent]
    public class GameDirector : MonoBehaviour
    {
        public GameObject limboEffects;
        public WorldMode worldMode { get; private set; }
        
        [SerializeField]
        private bool enableDebugModeOnStart;

        public static GameDirector Instance { get; private set; }

        [SerializeField]
        private SceneState[] sceneStates;

        [SerializeField] private SceneStateType dummySceneType;

        private SceneState currentSceneState, previousSceneState;

        private void OnEnable()
        {
            //EventManager.HintCollected += HintAdded;
            EventManager.WorldTypeChange += ChangeWorldType;
            EventManager.SceneStateChange += ChangeSceneState;
        }

        private void OnDisable()
        {
            //EventManager.HintCollected -= HintAdded;
            EventManager.WorldTypeChange -= ChangeWorldType;
            EventManager.SceneStateChange -= ChangeSceneState;
        }

        private void Awake()
        {
            //DontDestroyOnLoad(this);
            //CollectedHints = new List<HintState>();
            Instance = this;
            worldMode = WorldMode.RealWorld;
            //sceneStateLog = new Stack<SceneState>();
        }

        private void Start()
        {
            if (sceneStates != null && sceneStates.Length > 0)
            {
                ExitNonCurrentSceneStates();
                currentSceneState = sceneStates[0];
                currentSceneState.EnterState();
                ChangeSceneState(sceneStates[0].sceneStateType);
            }
            else Debug.LogError("Scene states need to be assigned on the Director object " + this.gameObject.name);

            //EventManager.OnWorldTypeChanged(worldMode);
            limboEffects.SetActive(false);
            if (enableDebugModeOnStart)
                EventManager.OnDebugMode(true);
            else EventManager.OnDebugMode(false);
            
            //ToggleWorldType(worldMode);
        }

        private void ExitNonCurrentSceneStates()
        {
            foreach (SceneState sState in sceneStates)
            {
                //if(sState != currentSceneState)
                sState.InitState();
            }
        }

        private void ChangeSceneState(SceneStateType state)
        {
            //Debug.Log("Scene state changed to " + state.name);
            if (state == dummySceneType)
                return;

            SceneState sState = null;
            if (state.backToScene)
            {
                //currentSceneState = previousSceneState;
                sState = previousSceneState;
            }
            else
            {
                for (int i = 0; i < sceneStates.Length; i++)
                {
                    if (sceneStates[i].sceneStateType == state)
                    {
                        sState = sceneStates[i];
                        break;
                    }
                }

                if (sState == null)
                {
                    Debug.LogError("No matching scene state found under name: " + state.sceneType);
                    return;
                }
            }

            if (currentSceneState != null)
            {
                //sceneStateLog.Push(sState);
                if(!currentSceneState.sceneStateType.nonStoredState)
                    previousSceneState = currentSceneState;
                currentSceneState.ExitState();
            }
            currentSceneState = sState;
            currentSceneState.EnterState();
        }

        private void ChangeWorldType(WorldMode wMode)
        {
            if (worldMode != wMode)
                worldMode = wMode;
            else return;
            
            if (worldMode == WorldMode.SpiritWorld)
            {
                //EventManager.OnWorldTypeChanged(worldMode);
                if (limboEffects != null)
                    limboEffects.SetActive(true);
            }
            else
            {
                //EventManager.OnWorldTypeChanged(worldMode);
                if (limboEffects != null)
                    limboEffects.SetActive(false); 
            }
        }

        /*private void HintAdded(HintState hint)
        {
            CollectedHints.Add(hint);
        }*/
        
        /*public bool WasHintCollected(HintType hintType)
        {
            foreach (HintState hState in CollectedHints)
            {
                if (hState.hintType == hintType)
                    return true;
            }
            return false;
        }*/
    }
}