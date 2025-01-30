using UnityEngine;
using TMPro;

public class TextHealth : HealthBar
{
    public TextMeshProUGUI healthValueText;

    public override void SetHealth(int amount)
    {
        healthValueText.text = amount.ToString();
    }

    public override void SetMaxHealth(int amount)
    {
        // Isnt shown
    }
}
