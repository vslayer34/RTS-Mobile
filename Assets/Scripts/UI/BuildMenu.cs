using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The behaviour and properties of units build menus
/// </summary>
public class BuildMenu : MonoBehaviour
{
    [field: SerializeField, Tooltip("Referance to the unit building buttons")]
    public GameObject[] UnitBuildButtons { get; private set; }
    
    [field: SerializeField, Tooltip("Referance to the unit ui container")]
    public Transform UnitCreationUI { get; private set; }

    private Image _unitIcon;
    private TextMeshProUGUI _unitDescription;


    private void Start()
    {
        _unitIcon = UnitCreationUI.GetChild(0).GetComponent<Image>();
        _unitDescription = UnitCreationUI.GetChild(1).GetComponent<TextMeshProUGUI>();
    }


    public void PopulateMenu(SO_UnitStat unit)
    {
        Debug.Log(unit.unitDescription);
        // _unitIcon.sprite = unit.unitIcon;
        // _unitDescription.text = unit.unitDescription;
    }
}
