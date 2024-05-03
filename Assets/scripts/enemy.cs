using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour
{
    private int hp = 1;
    private int moveSpeed = 1;
    [SerializeField] private int maxHP = 1;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject expGem;
    private AudioSource audioSource;

    Rigidbody2D rb;
    Vector2 direction;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = Player.GetInstance().transform;
        player = Player.GetInstance();
        hp = maxHP;

        // Find AudioManager in the scene
        Audiomanager audioManager = Audiomanager.GetInstance();
        

        if (audioManager != null)
        {
            // Access the shared AudioSource from AudioManager
            audioSource = audioManager.sharedAudioSource;

        }
        else
        {
            Debug.LogError("AudioManager not found in the scene!");
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHP;
    }
    // Update is called once per frame
    void Update()
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

    public void TakeDMG(int dmg)
    {
        hp -= dmg;
    }

    void Die()
    {
        //Instantiate(expGem, transform.position, Quaternion.identity); //debugging
        GameObject ExpGem = ObjectPool.GetInstance().GetPooledObject(expGem);
        ExpGem.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        ExpGem.SetActive(true);
        audioSource.clip = deathSound;
        audioSource.Play();
        Destroy(gameObject);
        //gameObject.setActive(false) when pooled;
    }
}
