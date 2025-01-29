using UnityEngine;

public class InteractableObjectChild : InteractableObject
{
    private InteractableObject parentObj;

    private void Awake()
    {
        parentObj = GetComponentInParent<InteractableObject>();
    }

    public override void Interact()
    {
        parentObj.Interact();
    }
}
