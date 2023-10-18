using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new unit stat", menuName = "Stats/Units")]
public class SO_UnitStat : ScriptableObject
{
    [Tooltip("Unit health")]
    public float health;
    [Tooltip("Unit movement speed")]
    public float speed;
}
