using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        delay02sLoadScene();
    }
    public void delay02sLoadScene()
    {
        StartCoroutine(DelayAndLoadScene(1f));
    }

    private IEnumerator DelayAndLoadScene( float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("index_scene");
    }
}
