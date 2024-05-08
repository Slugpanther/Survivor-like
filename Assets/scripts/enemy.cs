using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private int hp = 1;
    private int dmg = 1;
    public float moveSpeed = 1;
    [SerializeField] private int maxHP = 1;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject expGem;

    Rigidbody2D rb;
    Vector2 direction;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = Player.GetInstance().transform;
        player = Player.GetInstance();
        hp = maxHP;

    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        ScaleStats(Player.GetInstance().currentLvl);
        hp = maxHP;

    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (hp <= 0)
        {
            Die();
        }
        if (player != null)
        {
            direction = (player.transform.position - gameObject.transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }

    }
    public virtual void Attack() { }
    public virtual void TakeDMG(int dmg)
    {
        hp -= dmg;
    }

    public void ScaleStats(int playerLvl)
    {
        maxHP += 1 + playerLvl * 2;
        Debug.Log("HP: " + maxHP);
        moveSpeed += (int)playerLvl / 4; //scale move a tout les 4 lvls
    }

    public virtual void Die()
    {
        GameObject ExpGem = ObjectPool.GetInstance().GetPooledObject(expGem);
        if (ExpGem != null)
        {
            ExpGem.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            ExpGem.SetActive(true);
        }
        
        Audiomanager.GetInstance().sharedAudioSource.clip = deathSound;
        Audiomanager.GetInstance().sharedAudioSource.Play();
        Destroy(gameObject);
        //gameObject.setActive(false) when pooled;
    }

    //Triggers on enter only, needs to check for every 1/3 second
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Player.GetInstance().tag)
        {
            Player.GetInstance().takeDMG(dmg);
        }
    }
}
