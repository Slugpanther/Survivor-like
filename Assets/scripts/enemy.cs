using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int hp = 1;
    [SerializeField] private int maxHP = 1;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
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
        hp = maxHP;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    public void TakeDMG(int dmg)
    {
        hp -= dmg;
    }

    void Die()
    {
        
        audioSource.clip = deathSound;
        audioSource.Play();
        Destroy(gameObject);
    }
}
