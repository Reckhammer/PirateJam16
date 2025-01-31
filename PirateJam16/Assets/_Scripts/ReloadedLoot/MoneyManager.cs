using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int moneyCollected = 0;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MoneyCollected(moneyCollected);
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void MoneyCollected(int amountAdded)
    {
        moneyCollected += amountAdded;
        moneyText.text = moneyCollected.ToString();
        moneyText2.text = moneyCollected.ToString();
    }
}
