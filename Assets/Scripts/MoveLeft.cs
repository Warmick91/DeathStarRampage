using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float enemySpeedHorizontal = 2.5f;
    private float enemySpeedVertical;
    private float enemyLeftBoundary = -10;
    private bool enemyGoingUp;

    private float initialPositionY;
    private float veritcalMvtArea = 1;
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

        initialPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        DestroyInAbyss();
    }

    void MoveEnemy()
    {
        //Move left
        transform.Translate(Vector3.left * Time.deltaTime * enemySpeedHorizontal);

        //Move up and down
        if (transform.position.y <= initialPositionY - veritcalMvtArea)
        {
            enemyGoingUp = true;
            transform.Translate(Vector3.up * Time.deltaTime * enemySpeedVertical);
        }
        else if (transform.position.y >= initialPositionY + veritcalMvtArea)
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

    void DestroyInAbyss()
    {
        if (transform.position.x <= enemyLeftBoundary)
        {
            Destroy(gameObject);
        }
    }

}
