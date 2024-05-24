using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] UnityAction action;
    [SerializeField] UnityEvent unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        //action?.Invoke();
        unityEvent?.Invoke();   
    }
}
