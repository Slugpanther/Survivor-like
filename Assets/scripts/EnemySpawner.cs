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
    int rngStrongEnemyAmount = 2;
    float randomAngle;
    float randomDistance;
    float minDistance = 4.5f;
    float maxDistance = 6.5f;
    Vector2 spawnOffset;

    int strongOrWeak;

    [SerializeField] float spawnTime = 4;
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
            strongOrWeak = Random.Range(0, 2);
            if (strongOrWeak == 0)
            {
                for (int i = 0; i < rngEnemyAmount; i++) //change this to take out rng amount later?
                {
                    EnemyFactory.GetInstance().CreateRandomWeakEnemy(randomPosition); //ce que le prof m'a demander ==FORCE PLUSIEURS TYPES D'ENNEMIS DIFFERENT A SPAWN

                    //EnemyFactory.GetInstance().CreateWeakEnemy(enemyType[randomEnemy].gameObject, randomPosition); //what I had before
                    Randomizeposition();

                }
                strongOrWeak = Random.Range(0, 2);
            }
            else 
            {

                for (int i = 0; i < rngStrongEnemyAmount; i++) //change this to take out rng amount later?
                {
                    EnemyFactory.GetInstance().CreateRandomStrongEnemy(randomPosition); //ce que le prof m'a demander

                    //EnemyFactory.GetInstance().CreateStrongEnemy(enemyType[randomEnemy].gameObject, randomPosition); //what I had before
                    Randomizeposition();

                }
                strongOrWeak = Random.Range(0, 2);
            }
            
            rngEnemyAmount = Random.Range(1, 7 + Player.GetInstance().currentLvl);
            rngStrongEnemyAmount = Random.Range(1, 5);
            randomEnemy = Random.Range(0, enemyType.Length);


            yield return new WaitForSeconds(spawnTime);
        }
            
    }
}
