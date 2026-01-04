using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuAnimations : MonoBehaviour
{
    /// <summary>
    /// enum for the screen state
    ///  None: In game
    ///  Menu: there's a menu open
    /// </summary>
    private enum CurrentScreen { None, Menu }

    /// <summary>
    /// variable for the screen state
    /// </summary>
    private CurrentScreen _currentScreen = CurrentScreen.None;

    [SerializeField]
    private Animator _animator;
    
    // animation clips
    private int _popOutClip;
    private int _popInClip;

    private int _closeAnimationTrigger;


    private void Start()
    {
        _popInClip = Animator.StringToHash("Pop In");
        _closeAnimationTrigger = Animator.StringToHash("CloseMenu");
    }


    /// <summary>
    /// spawn the menu to the building location and open it
    /// </summary>
    /// <param name="parentCollider">the collider of the parent building to get its dimensions</param>
    public void OpenMenu(BoxCollider2D parentCollider)
    {   
        // _currentScreen = CurrentScreen.Menu;
        _animator.ResetTrigger(_closeAnimationTrigger);
        transform.position = new Vector2(parentCollider.transform.position.x, parentCollider.transform.position.y + parentCollider.offset.y);
        transform.gameObject.SetActive(true);
        MenuReference.Instance.Background.SetActive(true);

    }

    /// <summary>
    /// Close the menu when clicked anywhere but it
    /// Called by the background OnClick Unity event
    /// </summary>
    public void CloseMenu()
    {   
        if (_currentScreen == CurrentScreen.None)
        {
            return;
        }

        _animator.SetTrigger(_closeAnimationTrigger);
        MenuReference.Instance.Background.SetActive(false);

        // _currentScreen = CurrentScreen.None;
        
        // gameObject.SetActive(false);
    }

    // Called by tthe pop out animator
    public void SetCurrentMenuToActive() => _currentScreen = CurrentScreen.Menu;

    /// <summary>
    /// Disable the menu and change <paramref name="_currentScreen"/> mode
    /// Called by the pop in animator
    /// </summary>
    public void DisableMenu()
    {
        _currentScreen = CurrentScreen.None;
        gameObject.SetActive(false);  
    } 
}
