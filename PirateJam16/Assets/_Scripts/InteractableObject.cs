using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [Header("UI Text")]
    public string actionWord;
    public string niceName;

    public abstract void Interact();
}
