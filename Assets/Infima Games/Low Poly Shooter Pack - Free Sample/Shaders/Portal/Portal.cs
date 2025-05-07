using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent<Collider> OnPortalEntered;

    private void OnTriggerEnter(Collider other)
    {
        OnPortalEntered.Invoke(other);
    }
}
