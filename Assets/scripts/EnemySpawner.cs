using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] enemy[] enemyType = new enemy[20];


    Vector2 randomPosition = new Vector2(3,3); //make it random later
    int randomEnemy = 0;
    int rngEnemyAmount = 2;
    float randomAngle;
    float randomDistance;
    float minDistance = 3f;
    float maxDistance = 6f;
    Vector2 spawnOffset;

    float spawnTime = 5;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Randomizeposition();
            timer = 0;
            for (int i = 0; i < rngEnemyAmount; i++)
            {
                Instantiate(enemyType[randomEnemy], randomPosition, Quaternion.identity);
                Randomizeposition();
            }
            rngEnemyAmount = Random.Range(0, 7);
            randomEnemy = Random.Range(0, enemyType.Length);
        }
    }

    void Randomizeposition()
    {
        // Calculate a random angle in radians
        randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate a random distance between min and max distance
        randomDistance = Random.Range(minDistance, maxDistance);

        // Calculate the spawn position offset from the player so it doesnt spawn on/near him
        spawnOffset = new Vector2(Mathf.Cos(randomAngle) * randomDistance, Mathf.Sin(randomAngle) * randomDistance);

        // Calculate the spawn position
        randomPosition = (Vector2)player.transform.position + spawnOffset;
    }
}
