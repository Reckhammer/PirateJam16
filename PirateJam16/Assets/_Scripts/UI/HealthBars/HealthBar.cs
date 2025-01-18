using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    public abstract void SetHealth(int amount);
    public abstract void SetMaxHealth(int amount);
}
