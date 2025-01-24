using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    // todo: make a generic camera and movement class
    public FPCamera playerCamera;
    public FPMovement playerMovement;
    public Health playerHealth;
    public PlayerInventory playerInventory;
    public PlayerInteractableRaycaster playerInteractor;

    public bool disableMovementOnDeath = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (disableMovementOnDeath)
            playerHealth.Death += DisablePlayerMovement;
    }

    private void OnDestroy()
    {
        instance = null;

        playerHealth.Death -= DisablePlayerMovement;
    }

    public void EnablePlayerMovement()
    {
        playerCamera.EnableMovement();
        playerMovement.EnableMovement();
    }

    public void DisablePlayerMovement()
    {
        playerCamera.DisableMovement();
        playerMovement.DisableMovement();
    }
}
