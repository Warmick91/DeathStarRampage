using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float initialBackgroundPositionX;
    private float backgroundSpeed = 1.2f;

    private float enemySpeedHorizontal = 2.5f;
    private float enemySpeedVertical;
    private float enemyLeftBoundary = -10;
    private bool enemyGoingUp;

    private float initialEnemyPositionY;
    private float veritcalEnemyMvtArea = 1;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {

        enemySpeedVertical = Random.Range(1.0f, 3.0f);
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        int randomIndex = Random.Range(0, 2);
        if (randomIndex == 1)
        {
            enemyGoingUp = true;
        }
        else
        {
            enemyGoingUp = false;
        }

        initialEnemyPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
        MoveEnemy();
        DestroyInAbyss();
    }


    void MoveBackground()
    {
        if (this.CompareTag("Background"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * backgroundSpeed);
        }
    }
    void MoveEnemy()
    {
        if (this.CompareTag("EnemyPlanet"))
        {
            //Move left
            transform.Translate(Vector3.left * Time.deltaTime * enemySpeedHorizontal);

            //Move up and down
            if (transform.position.y <= initialEnemyPositionY - veritcalEnemyMvtArea)
            {
                enemyGoingUp = true;
                transform.Translate(Vector3.up * Time.deltaTime * enemySpeedVertical);
            }
            else if (transform.position.y >= initialEnemyPositionY + veritcalEnemyMvtArea)
            {
                enemyGoingUp = false;
                transform.Translate(Vector3.down * Time.deltaTime * enemySpeedVertical);
            }
            else
            {
                if (enemyGoingUp)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * enemySpeedVertical);
                }
                else
                {
                    transform.Translate(Vector3.down * Time.deltaTime * enemySpeedVertical);
                }
            }
        }

    }
    void DestroyInAbyss()
    {
        if (transform.position.x <= enemyLeftBoundary && this.CompareTag("EnemyPlanet"))
        {
            Destroy(gameObject);
        }
    }

}
