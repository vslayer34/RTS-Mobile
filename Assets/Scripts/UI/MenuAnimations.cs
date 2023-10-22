using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuAnimations : MonoBehaviour, IDeselectHandler, IPointerClickHandler
{
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
        transform.position = new Vector2(parentCollider.transform.position.x, parentCollider.transform.position.y + parentCollider.offset.y);
        transform.gameObject?.SetActive(true);
    }

    public void CloseMenu()
    {
        _animator.SetTrigger(_closeAnimationTrigger);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("I'm called");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("I'm Clicked");
    }
}
