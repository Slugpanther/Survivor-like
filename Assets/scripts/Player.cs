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
                Instantiate(weapons[0], gameObject.transform.position, Quaternion.identity);
            }
        }




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

    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y)*speed;
    }
}
