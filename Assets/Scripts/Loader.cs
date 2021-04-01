using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        var asyncOp = SceneManager.LoadSceneAsync(1);
        yield return new WaitForSeconds(5);
        asyncOp.allowSceneActivation = true;

    }

}
