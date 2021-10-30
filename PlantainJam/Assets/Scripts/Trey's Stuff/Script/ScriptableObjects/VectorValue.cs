using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    public Vector2 staticValue;

    public void OnAfterDeserialize() { initialValue = staticValue; }

    public void OnBeforeSerialize() { }
}
