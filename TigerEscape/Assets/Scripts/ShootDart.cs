using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDart : MonoBehaviour
{
    public float dartSpeed = 20f;
    public float dartLifeTime = 0.5f;

    private GameObject gameManager;

    private void Start()
    {
        // Destroy the dart afte this life time value
        Invoke("DestroyThisDart", dartLifeTime);
        gameManager = GameObject.Find("GameManager");
    }

    public void Update()
    {
        // Move the dart forward considering the speed value
        dartSpeed = gameManager.GetComponent<GameManagerX>().dartSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * dartSpeed);
    }

    private void DestroyThisDart()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
