using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cargo", menuName = "Scriptables/Cargo")]
public class Cargo : ScriptableObject
{
    public string id;
    public new string name;
    public string description;

    public float volume;
    public float baseValue;
    public string category;
    public List<string> attributes;
    public List<string> properties;
}
