using System.Collections;
using UnityEngine;

public class KeyItem : TransformItem
{
    public enum KeyType
    {
        Key,
        IDCard
    }

    [Header("Key Item")]
    public KeyType unlockType;
    public LockedObject selectedLock;

    private PlayerInventory playerInventory => PlayerManager.instance.playerInventory;

    public override void UseItem()
    {
        if (isEquipped /*&& selectedLock != null*/)
        {
            base.UseItem();
            if (selectedLock != null)
            {
                StartCoroutine(UseRoutine());
            }
        }
    }

    private IEnumerator UseRoutine()
    {
        // Do animations and stuff
        //base.UseItem();

        selectedLock.Unlock();

        yield return new WaitForSeconds(1f);

        playerInventory.Drop(this);
        Destroy(this.gameObject);
    }
}
