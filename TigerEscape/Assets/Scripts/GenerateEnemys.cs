using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemys : MonoBehaviour
{

    public GameObject tiger;
    public GameObject hunterPrefab;
    public GameObject meatPrefab;
    public GameObject[] carsArray;
    public float minDistance = 30f;
    public float maxDistance = 40f;
    public int spawnEnemyTime = 3;

    private GameObject gameManager;
    private bool finalWorldInst = false;
    private bool gameOver = false;

    // Call the 3 spawn fucntions repeatedly
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        InvokeRepeating("SpawnHunter", 0, spawnEnemyTime);
        InvokeRepeating("SpawnCar", 1, spawnEnemyTime);
        InvokeRepeating("SpawnMeat", 3, 5);
    }


    private void Update()
    {
        // When any of the booleans become true, can't instantiate new objects
        finalWorldInst = gameManager.GetComponent<GameManagerX>().IsAfinalWorld;
        gameOver = gameManager.GetComponent<GameManagerX>().gameOver;

    }


    // Instance a Hunter in the tiger's front when is called 
    private void SpawnHunter()
    {
        if(!finalWorldInst && !gameOver) Spawn(0);
    }

    // Instance a car
    private void SpawnCar()
    {
        if (!finalWorldInst && !gameOver) { 
            int ranCar = Random.Range(0, 2);
            if(ranCar == 0)
            {
                Spawn(1); //CAR 1
            }
            else if(ranCar == 1)
            {
                Spawn(2); //CAR 2
            }
        }
    }

    //Intance meat
    private void SpawnMeat()
    {
        if(!finalWorldInst && !gameOver) Spawn(3);
    }

    //Instance an object depending on the type, used for enemys and meat points, 0 = hunter, 1 = car1, 2 = car2, 3 = meat.
    private void Spawn(int type)
    {
        //Crate a random Vector3 for the enemy position considering the tigers position
        float xposition = tiger.transform.position.x + Random.Range(minDistance, maxDistance);
        float yposition = 0.155f;
        if (type == 3) yposition= 1.3f;
        float zposition = Random.Range(-5f, 1f);
        Vector3 enemyPos = new Vector3(xposition, yposition, zposition);

        // Crate the enemy facing the tiger
        Quaternion enemyRot = Quaternion.Euler(0, 270, 0);

        if (type == 0)
        {
            Instantiate(hunterPrefab, enemyPos, enemyRot);
        }
        else if (type == 1)
        {
            Instantiate(carsArray[0], enemyPos, enemyRot);
        }
        else if (type == 2)
        {
            Instantiate(carsArray[1], enemyPos, enemyRot);
        }
        else if (type == 3)
        {
            Instantiate(meatPrefab, enemyPos, enemyRot);
        }
    }
}
