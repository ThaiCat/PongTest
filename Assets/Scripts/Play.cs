using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : ButtonBase
{
    public override void ButtonAction()
    {
        var asyncOp = SceneManager.LoadSceneAsync(2);
        asyncOp.allowSceneActivation = true;
    }
}
