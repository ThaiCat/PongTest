using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSettings : ButtonBase
{
    public override void ButtonAction()
    {
        Settings.Singleton.Open();
    }
}