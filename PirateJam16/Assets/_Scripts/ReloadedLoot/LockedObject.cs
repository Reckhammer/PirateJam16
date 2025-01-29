using System.Collections;
using UnityEngine;

using static KeyItem.KeyType;

public class LockedObject : MonoBehaviour
{
    public KeyItem.KeyType keyType;
    public Vector3 unlockedRotation = new Vector3(0f, 90f, 0f);
    public float lerpSpeed = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<KeyItem>(out KeyItem triggeredKey))
        {
            if (triggeredKey.isEquipped && triggeredKey.unlockType == keyType)
                triggeredKey.selectedLock = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<KeyItem>(out KeyItem triggeredKey))
        {
            if (triggeredKey.isEquipped && triggeredKey.unlockType == keyType)
                triggeredKey.selectedLock = null;
        }
    }

    public void Unlock()
    {
        StartCoroutine(UnlockRoutine());
    }

    private IEnumerator UnlockRoutine()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(unlockedRotation);
        float elapsedTime = 0f;
        float duration = 1f / lerpSpeed; // Adjust duration based on speed

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.rotation = targetRotation; // Ensure it reaches the exact target rotation
    }
}
