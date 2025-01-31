using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollisionEventListener : MonoBehaviour
{
    public event Action<Collision> OnCollisionEntered;
    public event Action<Collision> OnCollisionExited;
    public event Action<Collision> OnCollisionStayed;

    public event Action<Collider> OnTriggerEntered;
    public event Action<Collider> OnTriggerExited;
    public event Action<Collider> OnTriggerStayed;

    // Todo: 2D event listeners

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEntered.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExited.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        //OnCollisionStayed.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        //OnTriggerStayed.Invoke(other);
    }
}
