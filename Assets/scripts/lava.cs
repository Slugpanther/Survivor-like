using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(weapon))]
[RequireComponent(typeof(Rigidbody2D))]
public class lava : MonoBehaviour

{
    Rigidbody2D rb;
    weapon wp;
    
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        wp = GetComponent<weapon>();
        wp.durationTimer = 8f;

        // Generate a random direction vector
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        // Apply the random direction and speed as velocity to the object
        rb.velocity = randomDirection * wp.projectileSpeed;
        
    }
    // Update is called once per frame
    void Update()
    {
        //put this in weapon later
        wp.durationTimer -= Time.deltaTime;
        if (wp.durationTimer <= 0)
        {
            Destroy(gameObject);
        }

    }

}
