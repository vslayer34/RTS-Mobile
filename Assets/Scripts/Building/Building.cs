using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Parent class that contains all friendly buildings common behaviours
/// </summary>
public class Building : MonoBehaviour, ITouchOnce
{
    [SerializeField,Tooltip("referance to the menus")]
    protected MenuReference _menuReference;
    
    [SerializeField, Tooltip("Prefab for the unit to be created")]
    protected Transform _createdUnit;

    [SerializeField, Tooltip("Manager input tracker")]
    protected SO_InputTracker _InputTracker;

    /// <summary>
    /// The coolider of that specific building
    /// </summary>
    protected BoxCollider2D _buildingCollider;

   

    private void Start()
    {
        _buildingCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _InputTracker.onOneTouch += DoTaskOnTouch;
    }

    private void OnDisable()
    {
        _InputTracker.onHoldTouch -= DoTaskOnTouch;
    }


    /// <summary>
    /// Dedect player's touch and act accordingly
    /// </summary>
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

    /// <summary>
    /// Open the specific menu
    /// </summary>
    /// <param name="menu">referance to the menu from the <paramref name="MenuReferance"/></param>
    public void OpenMenu(Transform menu)
    {
        menu.GetComponent<MenuAnimations>().OpenMenu(_buildingCollider);
    }
}
