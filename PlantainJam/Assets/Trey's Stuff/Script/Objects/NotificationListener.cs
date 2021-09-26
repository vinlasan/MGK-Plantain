using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotificationListener : MonoBehaviour
{
    public Notification notification;
    public UnityEvent signalEvent;

    public void OnNotificationRaised()
    {
        signalEvent.Invoke();
    }
    private void OnEnable()
    {
        notification.RegisterListener(this);
    }
    private void OnDisable()
    {
        notification.DeRegisterListener(this);
    }
}
