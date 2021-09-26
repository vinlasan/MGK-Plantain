using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Notification : ScriptableObject
{
    public List<NotificationListener> listeners = new List<NotificationListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            //listeners[i].OnNotificationRaised();
            listeners[i]?.OnNotificationRaised();
            //^ is the same thing as this -> if (listeners[i] != null)
            //{
            //listeners[i].OnNotificationRaised();
            //}
        }

    }
    public void RegisterListener(NotificationListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(NotificationListener listener)
    {
        listeners.Remove(listener);
    }
}
