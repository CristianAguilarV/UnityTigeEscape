using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarActions : MonoBehaviour
{
    public float carSpeed = 12f;
    public int carLifeTime = 10;

    private GameObject gameManager; 
    
    void Start()
    {
        // Destroy the car after this life time value
        Invoke("DestroyThisCar", carLifeTime);
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        MoveForward();
        carSpeed = gameManager.GetComponent<GameManagerX>().carSpeed;
    }

    // Move the car forward
    public void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed);
    }

    private void DestroyThisCar()
    {
        Destroy(gameObject);
    }
}
