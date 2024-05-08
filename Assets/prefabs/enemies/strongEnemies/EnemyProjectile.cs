using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IPoolable
{
    Rigidbody2D rb;
    [SerializeField] public float baseTimer;
    [SerializeField] public int dmg;
    [SerializeField] public float durationTimer = 5f;
    [SerializeField] public float projectileSpeed;
    Vector2 direction;

    // Start is called before the first frame update
    public void Reset()
    {
        durationTimer = baseTimer;
        direction = Player.GetInstance().transform.position.normalized - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //put this in weapon later
        durationTimer -= Time.deltaTime;
        if (durationTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        // Generate a direction vector
        direction =  Player.GetInstance().transform.position - transform.position;
        // Apply the direction and speed as velocity to the object
        rb.velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player.GetInstance().tag)
        {
            Player.GetInstance().takeDMG(dmg);
        }
    }
}
