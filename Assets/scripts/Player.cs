using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] weapons = new GameObject[8]; //change gameobject to access the attributes of weapon.cs
    [SerializeField] private Transform forwardWeaponSpawn;

    private float x, y;

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
            Instantiate(weapons[0], forwardWeaponSpawn.position, Quaternion.identity);
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
