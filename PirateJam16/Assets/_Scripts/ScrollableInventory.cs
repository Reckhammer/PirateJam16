using System.Collections.Generic;
using UnityEngine;

public class ScrollableInventory : PlayerInventory
{
    public Weapon activeWeapon;
    public List<Weapon> weaponSlots;

    private void Start()
    {
        activeWeapon = weaponSlots[0];
    }

    private void Update()
    {
        
    }
}
