using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Settings", menuName = "Setting") ]
public class Settings : ScriptableObject
{
    public int life = 200;

    public float tigerSpeed = 6f;
    public float carSpeed = 12f;
    public float dartSpeed = 40f;

    public int dartReduce = 10;
    public int carReduce = 30;
    public int hunterReduce = 20;
}
