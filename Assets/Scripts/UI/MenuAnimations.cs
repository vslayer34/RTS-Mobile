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
    private Animator _animator;
    
    // animation clips
    private int _popOutClip;
    private int _popInClip;

    private int _closeAnimationTrigger;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _popInClip = Animator.StringToHash("Pop In");
        _closeAnimationTrigger = Animator.StringToHash("CloseMenu");
    }


    /// <summary>
    /// spawn the menu to the building location and open it
    /// </summary>
    /// <param name="parentCollider">the collider of the parent building to get its dimensions</param>
    public void OpenMenu(BoxCollider2D parentCollider)
    {   
        _animator?.ResetTrigger(_closeAnimationTrigger);
        transform.position = new Vector2(parentCollider.transform.position.x, parentCollider.transform.position.y + parentCollider.offset.y);
        transform.gameObject?.SetActive(true);
        MenuReference.Instance.Background.SetActive(true);
    }

    /// <summary>
    /// Close the menu when clicked anywhere but it
    /// </summary>
    public void CloseMenu()
    {   
        if (_currentScreen == CurrentScreen.None)
            return;

        // Debug.Log("I'm called");
        _animator.SetTrigger(_closeAnimationTrigger);
        MenuReference.Instance.Background.SetActive(false);
        
        // gameObject.SetActive(false);
    }

    /// <summary>
    /// Disable the menu and change <paramref name="_currentScreen"/> mode
    /// </summary>
    public void DisableMenu()
    {
        if (_currentScreen == CurrentScreen.Menu)
        {
            // Debug.Log("Animation Event: at start");
            _currentScreen = CurrentScreen.None;
            gameObject.SetActive(false);
            // gameObject.SetActive(false);
        }
        else if (_currentScreen == CurrentScreen.None)
        {
            // Debug.Log("Animation Event: at end");
            _currentScreen = CurrentScreen.Menu;
        }
        // if (gameObject.activeSelf.Equals(true))
        // {
        //     // gameObject.SetActive(false);
        //     Debug.Log("I'm at this condition");
        //     return;
        // }
        // else
        // {
        //     Debug.Log("I'm at the else");
        //     _animator.ResetTrigger(_closeAnimationTrigger);
        //     gameObject.SetActive(false);
        // }
    } 
}
