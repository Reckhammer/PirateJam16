using UnityEngine;

public abstract class PlayerInventory : MonoBehaviour
{
    public abstract void Equip(EquippableObject itemToEquip);
    public virtual void SwapActive(EquippableObject itemToEquip) { throw new System.NotImplementedException(); }
    public virtual void SwapActive(int inventoryIndex) { throw new System.NotImplementedException(); }
    public virtual void AddToInventory(EquippableObject newItem) { throw new System.NotImplementedException(); }
    public abstract void Drop(EquippableObject itemToDrop);

    protected void SetAsChild(EquippableObject child) 
    {
        child.transform.parent = this.transform;
    }

    protected void RemoveChild(EquippableObject child, Transform newParent = null)
    {
        if (child.transform.parent != this.transform)
            Debug.LogWarning($"{child.name} is not a child of {this.name}", child);

        child.transform.parent = newParent;
    }

    public abstract bool IsEquipped(EquippableObject item);
    public abstract bool IsInInventory(EquippableObject item);

}
