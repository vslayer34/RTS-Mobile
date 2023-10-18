using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private SO_UnitStat _unitStat;
    [field: SerializeField, Header("Unit Stats"), Tooltip("Displays the unit health")]
    public float Health { get; protected set; }
    [field: SerializeField, Tooltip("Displays the unit movement speed")]
    public float Speed { get; protected set; }

    protected void InitialzeStats()
    {
        Health = _unitStat.health;
        Speed = _unitStat.speed;
    }
}
