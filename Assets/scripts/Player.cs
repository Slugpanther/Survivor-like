using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    //make it singleton?
    Rigidbody2D rb;
    Animator animator;
    bool isRunning;

    [SerializeField] private float speed;
    [SerializeField] private Weapon[] weapons = new Weapon[8]; //change gameobject to access the attributes of weapon.cs
    [SerializeField] private Transform forwardWeaponSpawn;
    [SerializeField] private AudioClip deathSound;

    int rngWeaponSpawnAmount;

    private float x, y;
    public int currentLvl = 1;
    public int exp;
    public int expToLvl;
    private int hp;
    private int maxHP = 50;


    private static Player Instance;

    public static Player GetInstance() => Instance;
    private void Awake()
    {
        // Ensure only one instance of Player exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another Player exists, destroy this one
            Destroy(gameObject);
        }
        hp = maxHP;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(SpawnWeapon());
    }



    // Update is called once per frame
    void Update()
    {
        /*
        //for lab only
        if (Input.GetKeyDown(KeyCode.E))
        {
            rngWeaponSpawnAmount = Random.Range(1, 11);

            for (int i = 0; i < rngWeaponSpawnAmount; i++) //fix this later
            {
                GameObject wpToSpawn = ObjectPool.GetInstance().GetPooledObject(weapons[0]); //gets anything from the pool
                wpToSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                wpToSpawn.SetActive(true);
                //Instantiate(weapons[0], gameObject.transform.position, Quaternion.identity);
                //new List<GameObject>().Add(weapons[0]);
            }


        }

        */

    }

    public IEnumerator SpawnWeapon()
    {
        Debug.Log("into spawn weapon");
        while (true)
        {
            /*
            foreach (var weapon in weapons)
            {
                yield return new WaitForSeconds(weapon.baseTimer);

                //spawn weapon
                for (int i = 0; i < weapon.amount; i++)
                {
                    //code to add weapon below

                    GameObject wpToSpawn = ObjectPool.GetInstance().GetPooledObject(weapon); //gets anything from the pool
                    wpToSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                    wpToSpawn.SetActive(true);
                    yield return new WaitForSeconds(weapon.interval);
                }
            }
            */

            yield return new WaitForSeconds(weapons[0].baseTimer);

            //spawn weapon
            for (int i = 0; i < weapons[0].amount; i++)
            {
                //code to add weapon below

                GameObject wpToSpawn = ObjectPool.GetInstance().GetPooledObject(weapons[0].gameObject); //gets anything from the pool
                wpToSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                wpToSpawn.SetActive(true);
                yield return new WaitForSeconds(weapons[0].interval);
            }
            

        }
    }


    void AddWeapon(Weapon newWeapon)
    {
        bool spaceFound = false;
        for (int i = 0; i < weapons.Length && !spaceFound; i++)
        {
            if (weapons[i] == null)
            {
                spaceFound = true;
                weapons[i] = newWeapon;
            }
        }

    }

    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y) * speed;
        if (x != 0 && Time.timeScale != 0)
        {
            transform.localScale = new Vector3(x > 0 ? -1 : 1, 1, 1);
        }
        if (rb.velocity != Vector2.zero)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        animator.SetBool("IsRunning", isRunning);
    }

    public void GainExp(int value) //call this when collecting exp gems
    {
        exp += value;
        if (exp >= expToLvl)
        {
            LevelUp();
            Debug.Log("level up");
        }
    }

    void LevelUp()
    {
        exp = 0;
        expToLvl = currentLvl * 5;
        currentLvl++;

        //trigger lvl up stat effects and weapon choice

        foreach (var weapon in weapons)
        {


        }
    }

    void Die()
    {
        //put game over screen and stuff later
        Audiomanager.GetInstance().sharedAudioSource.clip = deathSound;
        Audiomanager.GetInstance().sharedAudioSource.Play();
        Time.timeScale = 0f;

    }

    public void takeDMG(int value)
    {
        hp -= value;
        Debug.Log("Player hp :" + hp);
        if (hp <= 0)
        {
            Die();
        }
    }
}
