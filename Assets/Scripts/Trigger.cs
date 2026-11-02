using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [NonSerialized] public UnityEvent<GameObject> OnTrigger = new();
    private void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & layerMask.value) != 0)
        {
            Debug.Log("trigger");
            OnTrigger.Invoke(other.gameObject);
        }
    }
}
