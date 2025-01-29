using System.Reflection;
using UnityEngine;

public class Sandwich : TransformItem
{
    [Header("Sandwich")]
    public int healthAmt = 10;
    public int numUses = 3;
    private int timesUsed = 0;
    public float delay = 2f;
    private float nextTimeCanUse = 0f;

    private Health playerHealth => PlayerManager.instance.playerHealth;
    private PlayerInventory playerInventory => PlayerManager.instance.playerInventory;

    public override void UseItem()
    {
        if (isEquipped && Time.time > nextTimeCanUse)
            Heal();
    }

    private void Heal()
    {
        // Do animations and stuff
        base.UseItem();

        playerHealth.ChangeHealth(healthAmt);
        nextTimeCanUse = Time.time + delay;

        if (++timesUsed == numUses)
        {
            playerInventory.Drop(this);
            Destroy(this.gameObject);
        }
    }
}
