using System;
using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

public class ToggleDisplayTimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Toggle()
    {
        GameValues.GetGameValues().TogglePlayTime = !GameValues.GetGameValues().TogglePlayTime;
        Debug.Log("toggle");
    }
}
