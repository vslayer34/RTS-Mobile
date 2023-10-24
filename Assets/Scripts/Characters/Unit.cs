using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [field: SerializeField, Tooltip("Referance to the unit state")]
    public SO_UnitStat UnitStat { get; protected set; }

    [field: SerializeField, Header("Unit Stats"), Tooltip("Displays the unit health")]
    public float Health { get; protected set; }

    [field: SerializeField, Tooltip("Displays the unit movement speed")]
    public float Speed { get; protected set; }

    /// <summary>
    /// Initialize the state of the units to the setup values
    /// </summary>
    /// <value>The stats are stored in the scriptable objects for each unit</value>
    protected void InitialzeStats()
    {
        Health = UnitStat.health;
        Speed = UnitStat.speed;
    }
}   
