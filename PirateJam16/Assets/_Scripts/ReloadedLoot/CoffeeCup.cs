using System.Collections;
using UnityEngine;

public class CoffeeCup : TransformItem
{
    [Header("Coffee Cup")]
    public float moveSpeedDelta = 10f;
    public float effectDuration = 10f;
    private bool inEffect = false;
    private FPMovement playerMovement => PlayerManager.instance.playerMovement;

    public override void UseItem()
    {
        if (isEquipped && !inEffect)
            StartCoroutine(ActivateEffectCoroutine());
    }

    private IEnumerator ActivateEffectCoroutine()
    {
        // Do animations and stuff
        base.UseItem();

        inEffect = true;
        playerMovement.walkingSpeed += moveSpeedDelta;
        playerMovement.sprintSpeed  += moveSpeedDelta;

        yield return new WaitForSeconds(effectDuration);

        inEffect = false;
        playerMovement.walkingSpeed -= moveSpeedDelta;
        playerMovement.sprintSpeed  -= moveSpeedDelta;
    }
}
