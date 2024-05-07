using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Enemy[] enemyType = new Enemy[20];


    Vector2 randomPosition = new Vector2(3,3); //make it random later
    int randomEnemy = 0;
    int rngEnemyAmount = 2;
    float randomAngle;
    float randomDistance;
    float minDistance = 4f;
    float maxDistance = 6f;
    Vector2 spawnOffset;

    float spawnTime = 4;
    //float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy()); //check this when we change enemy types later on/after x minutes
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

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Randomizeposition();
            for (int i = 0; i < rngEnemyAmount; i++) //change this to take out rng amount later?
            {
                Instantiate(enemyType[randomEnemy], randomPosition, Quaternion.identity);
                Randomizeposition();

                //
                // EnemyFactory.GetInstance().CreateWeakEnemy(enemyType[randomEnemy], randomPosition);
                //
            }
            rngEnemyAmount = Random.Range(0, 7);
            randomEnemy = Random.Range(0, enemyType.Length);


            yield return new WaitForSeconds(spawnTime);
        }
            
    }
}
