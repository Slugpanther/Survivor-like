using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] enemy[] enemyType = new enemy[20];
    Vector2 randomPosition = new Vector2(3,3); //make it random later
    int randomEnemy = 0; //make it random later or wave based
    int rngEnemyAmount = 0;

    float spawnTime = 3;
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
            timer = 0;
            Instantiate(enemyType[randomEnemy], randomPosition,Quaternion.identity);
            if (randomEnemy == 0)
            {
                randomEnemy = 1;
            }
            else
            {
                randomEnemy = 0;
            }
        }
    }
}
