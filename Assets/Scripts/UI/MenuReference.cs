using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuReference : MonoBehaviour
{   

    // [field: SerializeField, Tooltip("Refernece to town center menu")]
    // public Transform TownCenterMenu { get; private set; }

    // [field: SerializeField, Tooltip("Refernece to barracks menu")]
    // public Transform BarracksMenu { get; private set; }

    [field: SerializeField, Tooltip("Refernece to barracks menu")]
    public Transform BuildMenu { get; private set; }
}
