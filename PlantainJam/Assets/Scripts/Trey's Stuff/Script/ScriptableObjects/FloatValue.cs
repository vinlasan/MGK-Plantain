using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable cannot be attached to anything in the scene, can live outside the scenes and assign values that can be read  in multiple scenes
[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize()
    {

    }
}