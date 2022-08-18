using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Property", menuName = "Property")]
public class Property : ScriptableObject
{
    public string address;
    public float lat;
    public float lon;
    public float baths;
    public int beds;

    public Sprite artwork;
}
