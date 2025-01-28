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
    //public LockedObject selectedLock;

    private PlayerInventory playerInventory => PlayerManager.instance.playerInventory;

    public override void UseItem()
    {
        if (isEquipped /*&& selectedLock != null*/)
        {
            //selectedLock.Unlock();
            playerInventory.Drop(this);
            Destroy(this.gameObject);
        }
    }
}
