using System.Collections;
using UnityEngine;
using static KeyItem;

public class HackObject : InteractableObject
{
    public float hackTime = 5f;
    private float timeHacked = 0f;
    private Hacker hacker;
    private bool hackStarted = false;

    public Transform openObject;
    public Vector3 hackedRotation;
    public float lerpSpeed = 2f;

    private void Start()
    {
        if (openObject == null)
            openObject = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hacker>(out Hacker triggeredHacker))
        {
            hacker = triggeredHacker;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Hacker>(out Hacker triggeredHacker))
        {
            if (hackStarted && timeHacked < hackTime)
            {
                StopAllCoroutines();
                hacker.HackExited();
                hackStarted = false;
            }
            
            hacker = null;
        }
    }

    public override void Interact()
    {
        if (hacker != null && hacker.isEquipped && !hackStarted)
        {
            StartCoroutine(HackRoutine());
        }
    }

    private IEnumerator HackRoutine()
    {
        hackStarted = true;
        hacker.HackTriggered();

        while (timeHacked <= hackTime)
        {
            yield return null;

            timeHacked += Time.deltaTime;
        }

        hacker.HackExited();
        StartCoroutine(UnlockRoutine());
    }

    private IEnumerator UnlockRoutine()
    {
        Quaternion startRotation = openObject.rotation;
        Quaternion targetRotation = Quaternion.Euler(hackedRotation);
        float elapsedTime = 0f;
        float duration = 1f / lerpSpeed; // Adjust duration based on speed

        while (elapsedTime < duration)
        {
            openObject.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        openObject.rotation = targetRotation; // Ensure it reaches the exact target rotation
    }
}
