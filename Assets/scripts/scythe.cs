using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Rigidbody2D))]
public class Scythe : MonoBehaviour
    //public class scythe : weapon
{
    Rigidbody2D rb;
    Weapon wp;

    public void Reset()
    {
        wp.durationTimer = 5f;
    }

    public void LvlUp() //specifiy those when doing balance tests
    {
        wp.dmg++;
        wp.scale += 1.5f;
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        wp = GetComponent<Weapon>();
        wp.durationTimer = 5f;

        //Scale weapons ONLY FOR LAB
        for (int i = 1; i < Player.GetInstance().currentLvl; i++)
        {
            LvlUp();
        }
        Debug.Log("Scythe dmg: " + wp.dmg);

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
