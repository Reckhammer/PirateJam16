using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [Header("UI Text")]
    public string actionWord;
    public string niceName;

    public abstract void Interact();
    public virtual void OnHoverEnter()
    {
        InteractableUI.instance.ShowText(GetInteractableText());
    }

    public virtual void OnHoverExit()
    {
        InteractableUI.instance.HideText();
    }

    private string GetInteractableText()
    {
        return $"Press E to {actionWord} {niceName}";
    }
}
