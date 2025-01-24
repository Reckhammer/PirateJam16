using UnityEngine;

public class EquippableObject : InteractableObject
{
    [Header("Equippable Object")]
    public Vector3 equippedPositionOffset;
    public Vector3 equippedRotationOffset;

    [Header("Read-Only")]
    public bool isEquipped = false;

    public override void Interact()
    {
        PlayerManager.instance.playerInventory.Equip(this);
    }

    public virtual void Equip() 
    {
        Debug.Log($"Equipping {this.name}", this);
        isEquipped = true;
        SetToEquipPosition(); 
    }

    public virtual void Unequip() 
    { 
        isEquipped = false;
    }

    public virtual void UseItem()
    {
        throw new System.NotImplementedException();
    }

    protected virtual void SetToEquipPosition()
    {
        this.transform.localPosition = equippedPositionOffset;
        this.transform.localRotation = Quaternion.Euler(equippedRotationOffset);
    }
}
