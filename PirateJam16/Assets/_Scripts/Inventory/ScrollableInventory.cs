using System.Collections.Generic;
using UnityEngine;

public class ScrollableInventory : PlayerInventory
{
    public EquippableObject activeWeapon;
    public List<EquippableObject> weaponSlots;

    private void Start()
    {
        activeWeapon = weaponSlots[0];
    }

    private void Update()
    {
        
    }

    public override void Equip(EquippableObject itemToEquip)
    {
        throw new System.NotImplementedException();
    }

    public override void Drop(EquippableObject itemToDrop)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsEquipped(EquippableObject item)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsInInventory(EquippableObject item)
    {
        throw new System.NotImplementedException();
    }
}
