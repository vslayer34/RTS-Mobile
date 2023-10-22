using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, ITouchOnce
{
    public void DoTaskOnTouch()
    {
        if (_buildingCollider.OverlapPoint(_InputTracker.touchPosition))
        {
            Debug.Log("Don't touch me PERVERT");
            Debug.Log("pop a menu");

            // Pop up build menu
            OpenMenu(_menuReference.BuildMenu);
            
        }        
    }

    public void OpenMenu(Transform menu)
    {
        menu.GetComponent<MenuAnimations>().OpenMenu(_buildingCollider);
    }

    private void OnEnable()
    {
        _InputTracker.onOneTouch += DoTaskOnTouch;
    }

    private void OnDisable()
    {
        _InputTracker.onHoldTouch -= DoTaskOnTouch;
    }

    [SerializeField,Tooltip("referance to the menus")]
    protected MenuReference _menuReference;
    
    [SerializeField, Tooltip("Prefab for the unit to be created")]
    protected Transform _createdUnit;

    [SerializeField, Tooltip("Manager input tracker")]
    protected SO_InputTracker _InputTracker;


    protected BoxCollider2D _buildingCollider;


    private void Start()
    {
        _buildingCollider = GetComponent<BoxCollider2D>();
    }
}
