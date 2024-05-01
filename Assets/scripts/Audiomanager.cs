using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    private static Audiomanager Instance;
    public AudioSource sharedAudioSource;

    public static Audiomanager GetInstance() => Instance; 

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional if AudioManager should persist between scenes
            // Create the AudioSource component
            sharedAudioSource = gameObject.AddComponent<AudioSource>();
            // Load AudioClip, set properties, etc.
        }
        else
        {
            // If another AudioManager exists, destroy this one
            Destroy(gameObject);
        }
    }
}
