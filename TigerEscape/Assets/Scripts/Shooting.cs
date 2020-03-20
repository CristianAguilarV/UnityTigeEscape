using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject dartPrefab;
    public GameObject dartStart;

    public int timeBetweenShots = 1;
    public int hunterLifeTime = 10;


    // Allows to shot repeatedly and destroy the hunter after a certain time
    private void Start()
    {
        InvokeRepeating("Shoot", 1, timeBetweenShots);
        Invoke("DestroyThisHunter", hunterLifeTime);
    }

    // Instance a Dart prefab when is called
    private void Shoot()
    {
        Instantiate(dartPrefab, dartStart.transform.position, dartStart.transform.rotation);
    }

    private void DestroyThisHunter()
    {
        Destroy(gameObject);
    }
}
