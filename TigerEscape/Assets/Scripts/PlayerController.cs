using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float tigerSpeed = 6f;
    private float turnSpeed = 10f;
    private float accelarationSpeed = 5f;
    private float horizontalInput;
    public float forwardInput;
    public bool collision = false;
    public int counter = 50;

    private MeshCollider tigerMesh;
    public GameObject skinObject;
    private SkinnedMeshRenderer smrTiger;

    private GameObject gameManager;
    public bool gameOver = false; 

    private void Start()
    {
        tigerMesh = GetComponent<MeshCollider>(); 
        smrTiger = skinObject.GetComponent<SkinnedMeshRenderer>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        tigerSpeed = gameManager.GetComponent<GameManagerX>().tigerSpeed;
        gameOver = gameManager.GetComponent<GameManagerX>().gameOver; // Ask if the game is over to GameManagerX
        if (!gameOver)
        {
            MoveTiger();
        }
        if(collision) // When the tiger lose life become inmortal
        {
            InmortalForCollision();
        }

        Confine();        
    }

    // Define Tiger movement, for arrows
    private void MoveTiger()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // if there are any touches currently
        if (Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);

            // if it began this frame
            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > Screen.width/2)
                {
                    transform.Translate(Vector3.right * 0.5f);// move right
                }
                else if (firstTouch.position.x < Screen.width/2)
                {
                    transform.Translate(-Vector3.right * 0.5f);// move left
                }
            }
        }

        // Allows to move rigth and left
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput );

        // Add the acceleration to the normal velocity of the tiger
        if (forwardInput >= 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * tigerSpeed + Vector3.forward * forwardInput * Time.deltaTime * accelarationSpeed );
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * tigerSpeed);
        }
    }

    // The tiger does not lose life for a few seconds
    public void InmortalForCollision()
    {   
        // Reduce in one unit the counter, at the end the tiger becomes mortal again
        if (counter != 0)
        {
            tigerMesh.enabled = false;
            counter--; //reduce the counter
        }
        else if(counter == 0)//counter become 0
        {
            tigerMesh.enabled = true;
            smrTiger.enabled = true;
            collision = false;
            counter = 50; // reset the counter
        }

        string counterStr = counter.ToString();
        // Make the tiger blink in case of collision, enable and diseable the skin mesh renderer
        if (counterStr.Substring(counterStr.Length - 1, 1) == "5")
        {
            smrTiger.enabled = false;
        }
        else if(counterStr.Substring(counterStr.Length - 1, 1) == "0")
        {
            smrTiger.enabled = true;
        }
    }


    // Define boundering to the sides
    private void Confine()
    {       
        //Define the rigth limit
        if (transform.position.z < -5.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5.5f);
        }
        //Define the left limit
        else if (transform.position.z > 1.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
        }
    }

    public void MoveTigerLeft()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.left * 100, ForceMode.Impulse);
    }

    public void MoveTigerRight()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.right * 100, ForceMode.Impulse);
    }

}
