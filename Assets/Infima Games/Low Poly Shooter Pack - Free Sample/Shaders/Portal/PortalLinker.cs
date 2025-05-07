using UnityEngine;

public class PortalLinker : MonoBehaviour
{
    [SerializeField] Portal Portal1;
    [SerializeField] Portal Portal2;
    [SerializeField] GameObject Player;

    private void Start()
    {
        Portal1.OnPortalEntered.AddListener((collider) => HandlePortalEntered(collider, Portal2));
        Portal2.OnPortalEntered.AddListener((collider) => HandlePortalEntered(collider, Portal1));
    }

    private void HandlePortalEntered(Collider collider, Portal destinationPortal)
    {
        if (collider == Player.GetComponent<Collider>())
        {
            Teleport(destinationPortal);
        }
    }

    private void Teleport(Portal destinationPortal)
    {
        Vector3 exitPosition = destinationPortal.transform.position + destinationPortal.transform.forward * 1.5f;
        exitPosition.y = Player.transform.position.y;

        Player.transform.position = exitPosition;
        Player.transform.rotation = destinationPortal.transform.rotation;
    }
}
