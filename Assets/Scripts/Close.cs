using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : ButtonBase
{
    public override void ButtonAction()
    {        
        Settings.Singleton.Close();
    }
}