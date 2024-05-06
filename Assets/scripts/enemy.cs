using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour
{
    private int hp = 1;
    private int dmg = 1;
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
        
        //add player level observer to call ScaleStats(player.currentLvl)

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
        ScaleStats(Player.GetInstance().currentLvl);
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

    public void ScaleStats(int playerLvl)
    {
        maxHP = maxHP + 1 + playerLvl * 2;
        Debug.Log("HP: " + maxHP);
        moveSpeed = moveSpeed + (int)playerLvl/5; //scale move a tout les 5 lvls
    }

    void Die()
    {
        GameObject ExpGem = ObjectPool.GetInstance().GetPooledObject(expGem);
        ExpGem.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        ExpGem.SetActive(true);
        audioSource.clip = deathSound;
        audioSource.Play();
        Destroy(gameObject);
        //gameObject.setActive(false) when pooled;
    }
}
