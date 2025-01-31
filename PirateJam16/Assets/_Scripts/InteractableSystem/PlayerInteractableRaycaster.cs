using UnityEngine;

public class PlayerInteractableRaycaster : MonoBehaviour
{
    public float maxRange = 3f;

    [Header("Read-Only")]
    public InteractableObject selectedItem;
    private Transform cameraTransform => Camera.main.transform;

    private void Update()
    {
        RaycastHit hit;

        //Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.red);

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, maxRange))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.TryGetComponent(out InteractableObject interactable))
            {
                selectedItem = interactable;
                selectedItem.OnHoverEnter();
                //Debug.Log($"{interactable.name} selected", this);
            }
            else
            {
                if (selectedItem != null)
                    selectedItem.OnHoverExit();
                selectedItem = null;
                InteractableUI.instance.HideText();
            }

            //Debug.Log($"{hitObject.name} was hit by a interactable raycast", this);
        }

        // Todo: use input action system
        if (Input.GetKeyDown(KeyCode.E) && selectedItem != null)
            selectedItem.Interact();
    }
}
