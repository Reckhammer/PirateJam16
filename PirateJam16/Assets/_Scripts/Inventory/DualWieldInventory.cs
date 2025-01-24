using UnityEngine;

public class DualWieldInventory : PlayerInventory
{
    public EquippableObject rightSlot;
    public EquippableObject leftSlot;

    private bool hasEquippedItem => rightSlot != null || leftSlot != null;

    public override void Equip(EquippableObject itemToEquip)
    {
        if (itemToEquip.isEquipped) return;

        Debug.Log($"Equipping {itemToEquip.name}", this);
        SetAsChild(itemToEquip);

        if (rightSlot == null) // No items are equipped
        {
            rightSlot = itemToEquip;
            itemToEquip.Equip();
            AdjustPositionForSlot(itemToEquip, true);
        }
        else if (leftSlot == null) // one item is equipped
        {
            leftSlot = itemToEquip;
            itemToEquip.Equip();
            AdjustPositionForSlot(itemToEquip, false);
        }
        else // both are equipped so drop one and equip the new one
        {
            Drop(leftSlot);
            leftSlot = itemToEquip;
            itemToEquip.Equip();
        }
    }

    public override void Drop(EquippableObject itemToDrop)
    {
        if (itemToDrop == null) return;

        if (itemToDrop == leftSlot)
        {
            leftSlot = null;
        }
        else
        {
            rightSlot = null;
        }

        RemoveChild(itemToDrop);
        itemToDrop.Unequip();
    }

    public override bool IsEquipped(EquippableObject item)
    {
        return item == rightSlot || item == leftSlot;
    }

    public override bool IsInInventory(EquippableObject item)
    {
        return IsEquipped(item);
    }

    private void Update()
    {
        // todo: use input action system
        if (Input.GetKeyDown(KeyCode.Q) && hasEquippedItem)
        {
            Drop(GetFilledSlot());
        }

        if (Input.GetMouseButtonDown(0) && rightSlot != null)
            rightSlot.UseItem();
        if (Input.GetMouseButtonDown(1) && leftSlot != null)
            leftSlot.UseItem();
    }

    private EquippableObject GetFilledSlot()
    {
        if (leftSlot != null)
            return leftSlot;
        else if (rightSlot != null)
            return rightSlot;

        return null;
    }

    private void AdjustPositionForSlot(EquippableObject item, bool isRight)
    {
        if (isRight)
        {
            item.transform.localPosition = item.equippedPositionOffset;
            item.transform.localEulerAngles = item.equippedRotationOffset;
        }
        else
        {
            Vector3 adjustedPosition = item.equippedPositionOffset;
            adjustedPosition.x *= -1;
            item.transform.localPosition = adjustedPosition;
            item.transform.localEulerAngles = item.equippedRotationOffset;
        }
    }
}
