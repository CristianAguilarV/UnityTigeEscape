using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(-3.64f, 3.91f, 0); //Distance between camera and player 

    private GameObject gameManager;
    private AudioSource cameraSource;
    public AudioClip gameOverClip;
    public bool gameOver = false;
    public bool isPlaying = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        cameraSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Camera follow the player
        transform.position = player.transform.position + offset;

        //Ask if the game is over
        gameOver = gameManager.GetComponent<GameManagerX>().gameOver;
        if(gameOver && !isPlaying) 
            PlayGameOverMusic();
    }


    //Change the music on win If the game is over
    private void PlayGameOverMusic()
    {
        cameraSource.clip = gameOverClip;
        cameraSource.Play();
        isPlaying = true; // Allows just one Play
    }

}
