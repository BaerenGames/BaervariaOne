using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "Scriptables/Ship")]
public class Ship : ScriptableObject
{
    public string id;
    public new string name;
    public int cargoCapacity;
    public float topSpeed;
    public float minSpeed;
    public float turnRate;
}
