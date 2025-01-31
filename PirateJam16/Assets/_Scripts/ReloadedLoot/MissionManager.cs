using System.Collections;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance;
    public GameObject endScreen;
    public Camera playerCamera;
    public Camera escapeCamera;
    public Animator vanAnimator;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void PlayerEscaped()
    {
        StartCoroutine(EscapeRoutine());
    }

    private IEnumerator EscapeRoutine()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PlayerManager.instance.playerCamera.canMove = false;
        PlayerManager.instance.playerMovement.canMove = false;
        PlayerManager.instance.playerMovement.gameObject.SetActive(false);

        playerCamera.gameObject.SetActive(false);
        escapeCamera.gameObject.SetActive(true);

        vanAnimator.SetTrigger("VanEscape");

        yield return new WaitForSeconds(2f);

        endScreen.SetActive(true);
    }
}
