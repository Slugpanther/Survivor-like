using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(weapon))]
[RequireComponent(typeof(Rigidbody2D))]
public class scythe : MonoBehaviour
    //public class scythe : weapon
{
    Rigidbody2D rb;
    weapon wp;

    public void Reset()
    {
        wp.durationTimer = 5f;
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        wp = GetComponent<weapon>();
        wp.durationTimer = 5f;

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
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }

}
