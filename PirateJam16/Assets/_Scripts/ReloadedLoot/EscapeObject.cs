using UnityEngine;

public class EscapeObject : InteractableObject
{
    public override void Interact()
    {
        MissionManager.instance.PlayerEscaped();
    }
}
