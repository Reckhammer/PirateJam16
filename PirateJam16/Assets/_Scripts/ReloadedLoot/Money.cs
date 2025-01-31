using UnityEngine;

public class Money : InteractableObject
{
    [Header("Money")]
    public int value = 100;

    public override void Interact()
    {
        MoneyManager.instance.MoneyCollected(value);
        Destroy(this.gameObject);
    }
}
