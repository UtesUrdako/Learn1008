using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrigeTrigger : MonoBehaviour
{
    public UnityEvent unityEvent;
    public UnityEvent unityEventExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            unityEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            unityEventExit.Invoke();
    }
}
