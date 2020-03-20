using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCube : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(-5, 0.5f, 0); //Distance between cube and player 

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
