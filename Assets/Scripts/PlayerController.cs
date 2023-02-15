using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float breakingArea = 1.5f;
    private float leftFinalBound = -8f;
    private float rightFinalBound = 0;
    private float bottomFinalBound = -4.0f;
    private float topFinalBound = 4.0f;
    private float playerSpeed = 1000;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(Vector3.up * playerSpeed * Time.deltaTime * verticalInput);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector3.right * playerSpeed * Time.deltaTime * horizontalInput);
        }

        BoundPlayer();

    }
    void BoundPlayer()
    {
        if (transform.position.y > topFinalBound)
        {
            transform.position = new Vector3(transform.position.x, topFinalBound, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }

        DampAndBoundTop();

        DampAndBoundBottom();

        DampAndBountRight();

        DampAndBoundLeft();


    }


    void DampAndBoundTop()
    {
        if (transform.position.y > topFinalBound - breakingArea)
        {
            if (playerRb.velocity.y > 0 && Input.GetKey(KeyCode.W) && transform.position.y < topFinalBound)
            {
                playerRb.velocity *= 0.95f;
            }

            if (transform.position.y > topFinalBound)
            {
                transform.position = new Vector3(transform.position.x, topFinalBound, transform.position.z);
                playerRb.velocity = Vector3.zero;
            }

        }
    }

    void DampAndBoundBottom()
    {
        if (transform.position.y < bottomFinalBound + breakingArea)
        {
            if (playerRb.velocity.y < 0 && Input.GetKey(KeyCode.S) && transform.position.y > bottomFinalBound)
            {
                playerRb.velocity *= 0.95f;
            }

            if (transform.position.y < bottomFinalBound)
            {
                transform.position = new Vector3(transform.position.x, bottomFinalBound, transform.position.z);
                playerRb.velocity = Vector3.zero;
            }

        }
    }

    void DampAndBountRight()
    {
        if (transform.position.x > rightFinalBound - breakingArea)
        {
            if (playerRb.velocity.x > 0 && Input.GetKey(KeyCode.D) && transform.position.x < rightFinalBound)
            {
                playerRb.velocity *= 0.95f;
            }

            if (transform.position.x > rightFinalBound)
            {
                transform.position = new Vector3(rightFinalBound, transform.position.y, transform.position.z);
                playerRb.velocity = Vector3.zero;
            }
        }
    }

    void DampAndBoundLeft()
    {
        if (transform.position.x < leftFinalBound + breakingArea)
        {
            if (playerRb.velocity.x < 0 && Input.GetKey(KeyCode.A) && transform.position.x > leftFinalBound)
            {
                playerRb.velocity *= 0.95f;
            }

            if (transform.position.x < leftFinalBound)

            {
                transform.position = new Vector3(leftFinalBound, transform.position.y, transform.position.z);
                playerRb.velocity = Vector3.zero;
            }
        }
    }

}
