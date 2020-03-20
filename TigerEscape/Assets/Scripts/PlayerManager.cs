using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{ 
    private Animator tigerAnimator;
    private GameObject gameManager;
    private bool gameOver = false;
    private bool isChangeAnimator = false;

    private void Start()
    {
        tigerAnimator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        ChangeTigerAnimator();
    }

    // Change the Tiger's Animator if the game is over, once
    private void ChangeTigerAnimator()
    {
        gameOver = gameManager.GetComponent<GameManagerX>().gameOver;
        if (gameOver && !isChangeAnimator)
        {
            tigerAnimator.SetBool("final", true);
            isChangeAnimator = true;
        } 
    }

}
