using UnityEngine;
using TMPro;

public class InteractableUI : MonoBehaviour
{
    public static InteractableUI instance;
    public TextMeshProUGUI promptText;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HideText();
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void ShowText(string text)
    {
        promptText.text = text;
        promptText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        promptText.gameObject.SetActive(false);
    }
}
