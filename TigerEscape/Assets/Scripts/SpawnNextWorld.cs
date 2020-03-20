using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextWorld : MonoBehaviour
{
    public GameObject worldPrefab;
    public GameObject finalWorldPrefab;
    public GameObject gameManager; 
    public float nextInstance = 97.53f;
    public bool canInstantiate = true;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        // Ask if can instantiate a new world
        canInstantiate = gameManager.GetComponent<GameManagerX>().canInstantiate;
    }

    // Instance a new World prefab when the tigger collides with a transparent wall
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flag"))
        {
            if (canInstantiate)
            {
                // Calculate the x position adding "nextInstance" to the actual wall position
                Vector3 nextWorldPos = new Vector3(transform.position.x + nextInstance, 0, 0);
                Instantiate(worldPrefab, nextWorldPos, Quaternion.Euler(0, 0, 0));

                //Advise the Game Manager to increase the number of world
                gameManager.GetComponent<GameManagerX>().IncreaseWorlds();
            }
            else
            {
                //Create the final scenario
                Vector3 nextWorldPos = new Vector3(transform.position.x + nextInstance, 0, 0);
                Instantiate(finalWorldPrefab, nextWorldPos, Quaternion.Euler(0, 0, 0));
                gameManager.GetComponent<GameManagerX>().SetBoolFinal(true);
            }
        }    
    }
}
