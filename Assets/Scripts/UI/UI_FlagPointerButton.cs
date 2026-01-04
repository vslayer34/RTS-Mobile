using System;
using UnityEngine;
using UnityEngine.UI;



public class UI_FlagPointerButton : MonoBehaviour
{
    public event Action OnFlagButtonPressed;
    public event Action<Vector3> OnNewFlagPositionSelected;

    [SerializeField]
    private Button _flagBtn;

    [SerializeField]
    private SO_InputTracker _inputTracker;

    [SerializeField]
    private FlagPoint _flagPrefab;

    private FlagPoint _flagInstanse;

    private bool _placingFlag;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _flagBtn.onClick.AddListener(PlaceBuildingFlag);
    }

    private void OnDestroy()
    {
        _flagBtn.onClick.RemoveListener(PlaceBuildingFlag);
    }

    // Member Methods------------------------------------------------------------------------------

    private void StartPlacingFlag() => _placingFlag = true;

    // Signal Methods------------------------------------------------------------------------------

    private void PlaceBuildingFlag()
    {
        Debug.Log("Start placing flag");

        if (!_flagInstanse)
        {
            _flagInstanse = Instantiate(_flagPrefab, _inputTracker.touchPosition, Quaternion.identity);
        }
        
        // subscribe to the button clicks and 
        OnFlagButtonPressed += _flagInstanse.GettingFlagReadyToBePlaced;
        _inputTracker.onOneTouch += ListenToFlagNewPosition;
    }

    private void ListenToFlagNewPosition()
    {
        OnNewFlagPositionSelected += _flagInstanse.PutTheFlagDown;
        OnNewFlagPositionSelected(_inputTracker.touchPosition);

        OnFlagButtonPressed -= _flagInstanse.GettingFlagReadyToBePlaced;
        _inputTracker.onOneTouch -= ListenToFlagNewPosition;
    }
}