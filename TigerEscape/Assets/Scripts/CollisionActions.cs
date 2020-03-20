using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActions : MonoBehaviour
{
    public int dartReduce = 10;
    public int carReduce = 30;
    public int hunterReduce = 20;

    public bool isStop = false; 

    private AudioSource collisionSounds;
    public AudioClip loseLifeClip;
    public AudioClip winPointsClip;

    private GameObject gameManager;

    private void Start()
    {
        collisionSounds = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        isStop = GetComponent<PlayerController>().collision;
        dartReduce = gameManager.GetComponent<GameManagerX>().dartReduce;
        carReduce = gameManager.GetComponent<GameManagerX>().carReduce;
        hunterReduce = gameManager.GetComponent<GameManagerX>().hunterReduce;
    }


    // Reduce the tiger life depending on the collision objetc or increase the player's points
    private void OnCollisionEnter(Collision collision)
    {
        if (!isStop)// Not reduce life of the tiger if is true
        {
            // Reduce the tiger's life
            if (collision.gameObject.CompareTag("dart") || collision.gameObject.CompareTag("car") || collision.gameObject.CompareTag("hunter"))
            {
                // Assing the damage
                int reduceValue = 0;
                if (collision.gameObject.CompareTag("dart")) reduceValue = dartReduce;
                else if (collision.gameObject.CompareTag("car")) reduceValue = carReduce;
                else if (collision.gameObject.CompareTag("hunter")) reduceValue = hunterReduce;

                //The object is destroy after the collision
                Destroy(collision.gameObject);
                gameManager.GetComponent<GameManagerX>().ReduceLife(reduceValue);
                gameObject.GetComponent<PlayerController>().collision = true; // When the tiger lose life, become inmortal for a few seconds
                isStop = true;
                collisionSounds.PlayOneShot(loseLifeClip, 0.3f);
            }

            // Increase player's points
            else if (collision.gameObject.CompareTag("meat"))
            {
                Destroy(collision.gameObject);
                gameManager.GetComponent<GameManagerX>().IncreasePoints();
                collisionSounds.PlayOneShot(winPointsClip, 1.0f);
            }
            
            // Collision with the final transparent object--> tigger stop
            else if (collision.gameObject.CompareTag("final"))
            {
                // Alert the Game is over to the GameManagerX
                gameManager.GetComponent<GameManagerX>().SetGameOverBool();
            }
        }
    }
}
