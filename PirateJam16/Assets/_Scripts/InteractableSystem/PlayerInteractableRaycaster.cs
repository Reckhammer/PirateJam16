using UnityEngine;

public class PlayerInteractableRaycaster : MonoBehaviour
{
    public InteractableObject selectedItem;
    private Transform cameraTransform => Camera.main.transform;

    private void Update()
    {
        RaycastHit hit;

        //Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.red);

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.TryGetComponent(out InteractableObject interactable))
            {
                selectedItem = interactable;
                //Debug.Log($"{interactable.name} selected", this);
            }
            else
            {
                selectedItem = null;
            }

            //Debug.Log($"{hitObject.name} was hit by a interactable raycast", this);
        }

        // Todo: use input action system
        if (Input.GetKeyDown(KeyCode.E) && selectedItem != null)
            selectedItem.Interact();
    }
}
