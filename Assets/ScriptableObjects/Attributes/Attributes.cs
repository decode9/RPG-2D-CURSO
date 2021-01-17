using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Attributes")]
public class Attributes: ScriptableObject
{
    // Start is called before the first frame update
    [Tooltip("Movement Velocity")]
    public int velocity;
    [Tooltip("Attack Power")]
    public int ataque;
}
