using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class straightProjectile : MonoBehaviour
{

    [SerializeField] private GameObject owner; //get owner type to block same type collision trigger AKA self-fire/friendly-fire ======> CHANGE SINCE THIS WILL BE ONLY ENEMYPROJECTILES
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable() //trigger when you create an instance of this script
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 5f * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
