using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //make it singleton?
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] weapons = new GameObject[8]; //change gameobject to access the attributes of weapon.cs
    [SerializeField] private Transform forwardWeaponSpawn;

    int rngWeaponSpawnAmount;

    private float x, y;
    public int currentLvl = 1;
    int exp;
    public int expToLvl;


    private static Player Instance;

    public static Player GetInstance() => Instance;
    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another AudioManager exists, destroy this one
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //for lab only
        if (Input.GetKeyDown(KeyCode.E))
        {
            rngWeaponSpawnAmount = Random.Range(1, 11);


            for (int i = 0; i < rngWeaponSpawnAmount; i++)
            {
                GameObject wpToSpawn = ObjectPool.GetInstance().GetPooledObject(weapons[0]); //gets anything from the pool
                wpToSpawn.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                wpToSpawn.SetActive(true);
                //Instantiate(weapons[0], gameObject.transform.position, Quaternion.identity);
                //new List<GameObject>().Add(weapons[0]);
            }
        }
        if (weapons[1]) { }




        /*
        foreach (var weapon in weapons) {
            weapon.timer -= Time.deltatime;
            if(weapon.timer <= 0){
                Instantiate(weapon, transform.position, Quaternion.identity); //add proper movement/rotation/scale based on the weapon stats and modifiers
                weapon.timer += weapon.baseTimer;
            }
        }
        */
    }

    void AddWeapon(GameObject newWeapon)
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
    }

    public void GainExp(int value) //call this when collecting exp gems
    {
        exp += value;
        if (exp >= expToLvl)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        exp = 0;
        expToLvl = currentLvl * 5;
        currentLvl++;
        //trigger lvl up stat effects and weapon choice
    }
}
