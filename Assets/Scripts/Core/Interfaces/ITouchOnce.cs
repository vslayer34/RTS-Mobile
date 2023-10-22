using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchOnce
{
    void DoTaskOnTouch();

    void OpenMenu(Transform menu)
    {
        menu.gameObject.SetActive(true);
    }
}
