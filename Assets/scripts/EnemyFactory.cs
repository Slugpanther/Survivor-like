using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject weakEnemy;
    [SerializeField] GameObject strongEnemy;

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

    public GameObject CreateWeakEnemy()
    {
        return Instantiate(weakEnemy, Vector3.zero, Quaternion.identity);
    }
    public GameObject CreateWeakEnemy(Vector2 position)
    {
        return Instantiate(weakEnemy, position, Quaternion.identity);
    }

    public GameObject CreateWeakEnemy(GameObject myEnemy)
    {
        return Instantiate(myEnemy, Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateWeakEnemy(GameObject myEnemy, Vector2 position)
    {
        return Instantiate(myEnemy, position, Quaternion.identity);
    }

    public GameObject CreateStrongEnemy()
    {
        return Instantiate(strongEnemy, Vector3.zero, Quaternion.identity);
    }





}
