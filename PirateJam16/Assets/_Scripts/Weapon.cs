using UnityEngine;

public class Weapon : InteractableObject
{
    
    public Vector3 equipedPositionOffset;
    public Vector3 equipedRotationOffset;

    public override void Interact()
    {
        Debug.Log($"{this.name} has been interacted with");
    }
}
