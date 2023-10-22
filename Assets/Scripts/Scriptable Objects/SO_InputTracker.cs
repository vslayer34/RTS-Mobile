using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new input tracker", menuName = "Managers/tracker")]
public class SO_InputTracker : ScriptableObject
{
    public Action onOneTouch;
    public Action onHoldTouch;



    public Vector3 touchPosition;
}
