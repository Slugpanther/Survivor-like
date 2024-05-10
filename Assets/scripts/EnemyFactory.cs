using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject[] weakEnemy; //default weak enemy --> devenu un array pour le projet
    [SerializeField] GameObject[] strongEnemy; //default strong enemy
    int randomEnemy;
    int weakLength = 0;
    int strongLength = 0;
    private static EnemyFactory Instance;

    public static EnemyFactory GetInstance() => Instance;

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // If another EnemyFactory exists, destroy this one
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0;i < weakEnemy.Length; i++)
        {
            if (weakEnemy[i] != null)
            {
                weakLength++;
            }
        }
        for (int i = 0; i < strongEnemy.Length; i++)
        {
            if (strongEnemy[i] != null)
            {
                strongLength++;
            }
        }
    }

    public GameObject CreateRandomWeakEnemy()
    {
        randomEnemy = Random.Range(0, weakLength);
        return Instantiate(weakEnemy[randomEnemy], Vector3.zero, Quaternion.identity);
    }
    public GameObject CreateRandomWeakEnemy(Vector2 position)
    {
        randomEnemy = Random.Range(0, weakLength);
        return Instantiate(weakEnemy[randomEnemy], position, Quaternion.identity);
    }

    public GameObject CreateWeakEnemy(GameObject myEnemy)
    {
        return Instantiate(myEnemy, Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateWeakEnemy(GameObject myEnemy, Vector2 position)
    {
        return Instantiate(myEnemy, position, Quaternion.identity);
    }

    public GameObject CreateRandomStrongEnemy()
    {
        randomEnemy = Random.Range(0, strongLength);
        return Instantiate(strongEnemy[randomEnemy], Vector3.zero, Quaternion.identity);
    }
    public GameObject CreateRandomStrongEnemy(Vector2 position)
    {
        randomEnemy = Random.Range(0, strongLength);
        return Instantiate(strongEnemy[randomEnemy], position, Quaternion.identity);
    }


    //these only for scripted spawns
    public GameObject CreateStrongEnemy(GameObject myEnemy)
    {
        return Instantiate(myEnemy, Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateStrongEnemy(GameObject myEnemy, Vector2 position)
    {
        return Instantiate(myEnemy, position, Quaternion.identity);
    }





}
