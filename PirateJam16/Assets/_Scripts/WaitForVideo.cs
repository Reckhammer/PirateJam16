using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForVideo : MonoBehaviour
{
    public float videoLength = 45f;
    public string sceneToLoad = "Invalid Scene"; // Todo: some make only scenes in build order as only options

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAfterVideo());
    }

    IEnumerator LoadSceneAfterVideo()
    {
        yield return new WaitForSeconds(videoLength);

        SceneManager.LoadScene(sceneToLoad);
    }
}
