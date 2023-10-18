using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCenter : Building, ITouchOnce
{
    public void DoTaskOnTouch()
    {
        Debug.Log("Don't touch me PERVERT");
    }
}
