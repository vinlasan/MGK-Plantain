using UnityEngine;
using UnityEditor;
using Gameplay;

namespace EditorTools
{
    [CustomEditor(typeof(GameDirector))]
    public class DirectorTester : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(EditorApplication.isPlaying)
            {
                if(GUILayout.Button("Spirit Wall Type"))
                    EventManager.OnWorldTypeChanged(WorldMode.SpiritWorld);
                
                if (GUILayout.Button("Real Wall Type"))
                    EventManager.OnWorldTypeChanged(WorldMode.RealWorld);
            }
        }
    }
}