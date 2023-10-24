using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuAnimations : MonoBehaviour
{
    private enum CurrentScreen { None, Menu }

    private CurrentScreen _currentScreen = CurrentScreen.None;
    private Animator _animator;
    private int _popOutClip;
    private int _popInClip;

    private int _closeAnimationTrigger;


    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        Debug.Log(EventSystem.current.currentSelectedGameObject);

    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _popInClip = Animator.StringToHash("Pop In");
        _closeAnimationTrigger = Animator.StringToHash("CloseMenu");
    }


    public void OpenMenu(BoxCollider2D parentCollider)
    {   
        _animator?.ResetTrigger(_closeAnimationTrigger);
        transform.position = new Vector2(parentCollider.transform.position.x, parentCollider.transform.position.y + parentCollider.offset.y);
        transform.gameObject?.SetActive(true);
        MenuReference.Instance.Background.SetActive(true);
    }

    public void CloseMenu()
    {   
        if (_currentScreen == CurrentScreen.None)
            return;

        Debug.Log("I'm called");
        _animator.SetTrigger(_closeAnimationTrigger);
        MenuReference.Instance.Background.SetActive(false);
        
        // gameObject.SetActive(false);
    }

    public void DisableMenu()
    {
        if (_currentScreen == CurrentScreen.Menu)
        {
            Debug.Log("Animation Event: at start");
            _currentScreen = CurrentScreen.None;
            gameObject.SetActive(false);
            // gameObject.SetActive(false);
        }
        else if (_currentScreen == CurrentScreen.None)
        {
            Debug.Log("Animation Event: at end");
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
