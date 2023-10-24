using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuReference : MonoBehaviour
{   
    public static MenuReference Instance { get; private set; }

    // [field: SerializeField, Tooltip("Refernece to town center menu")]
    // public Transform TownCenterMenu { get; private set; }

    // [field: SerializeField, Tooltip("Refernece to barracks menu")]
    // public Transform BarracksMenu { get; private set; }

    [field: SerializeField, Tooltip("Refernece to barracks menu")]
    public Transform BuildMenu { get; private set; }

    [field: SerializeField, Tooltip("Referance to the background to close menues")]
    public GameObject Background { get; private set; }

    private void Start()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    public void CloseMenu()
    {
        BuildMenu.GetComponent<MenuAnimations>().CloseMenu();
    }
}
