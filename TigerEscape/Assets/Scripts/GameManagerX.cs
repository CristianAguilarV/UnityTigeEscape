using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public int limitsWorlds = 1;
    private int numerOfWorlds = 0;
    public bool canInstantiate = true;
    public bool IsAfinalWorld = false;

    public bool gameOver = false;
    private bool gameOverFunctionUse = false;

    public int score = 0;
    public int life = 100;

    public float tigerSpeed = 6f;
    public float carSpeed = 12f;
    public float dartSpeed = 40f;

    public int dartReduce = 10;
    public int carReduce = 30;
    public int hunterReduce = 20;
    

    //This class also manage the Score and Life UI elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gameOverText;

    public Button RestartButton;


    private void Start()
    {
        scoreText.text = "Puntaje: " + score;
        lifeText.text = "Vida: " + life;
        finalScoreText.enabled = false;
        gameOverText.enabled = false;
    }


    private void Update()
    {
        UpdateTextUIValues();
        if (gameOver && !gameOverFunctionUse) GameOver();
    }

    private void UpdateTextUIValues()
    {
        scoreText.text = "Puntaje: " + score;
        lifeText.text = "Vida: " + life;
    }


    // Reduce the tiger life in the specific value, called by CollisionActionsX
    public void ReduceLife(int value)
    {
        int diference = life - value;
        // Only removes life if the diference is not negative
        if (diference > 0)
        {
            life = life - value;
        }
        else
        {
            life = 0;
            gameOver = true;
        }
    }

    // Increase the points after a collision with meat, called by CollisionActionsX
    public void IncreasePoints()
    {
        score += 10;
    }


    public void IncreaseWorlds()
    {
        numerOfWorlds++;

        // After a certain value of worlds, does not allows to create a new one
        if(numerOfWorlds == limitsWorlds)
        {
            canInstantiate = false;
        }
    }

    // The final World has been instantiate
    public void SetBoolFinal(bool value)
    {
        IsAfinalWorld = value;
    }

    // Game Over
    public void SetGameOverBool()
    {
        gameOver = true;
    }

    //Finish the game, allows to reset
    public void GameOver()
    {// Generate new enemys, tigers animator and change the music is doing in the respective classes, GenerateEnemys.cl, PlayerManager.cs, FollowPlayer.cs

        //Change the UI elements
        scoreText.enabled = false;
        lifeText.enabled = false;
        score += life;

        finalScoreText.enabled = true;
        finalScoreText.text = "Puntaje Final: " + score;
        RestartButton.gameObject.SetActive(true);
        if (IsAfinalWorld)
        {
            gameOverText.text = "¡Felicidades!";
        }
        gameOverText.enabled = true;

        gameOverFunctionUse = true; // The game over function can be called just once
        
    }

    //Restart the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
