using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneScript : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "GameScene";
    [SerializeField] float sceneTransitionDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveNextSceneAfterTwoSeconds());
    }

    IEnumerator MoveNextSceneAfterTwoSeconds(){
        yield return new WaitForSeconds(sceneTransitionDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
