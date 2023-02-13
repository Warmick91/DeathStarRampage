using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public float enemyBoundaryY = 4.0f;

    private float startTime = 2.0f;
    private float intervalTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {

        int randomIndex = Random.Range(0, enemies.Length);
        float randomY = Random.Range(-enemyBoundaryY, enemyBoundaryY);
        Vector3 randomStartPosition = new Vector3(13, randomY, -1);

        Instantiate(enemies[randomIndex], randomStartPosition, transform.rotation);
    }
}
