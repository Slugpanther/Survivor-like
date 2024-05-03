using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour, IPoolable
{
    private Player player;
    [SerializeField] int value;

    private void Start()
    {

        player = Player.GetInstance();
    }


    private void OnCollisionEnter2D(Collision2D collision) //collision with the grab radius (magnet)
    {
        //Debug.Log("exp hit");
        Collider2D hitCollider = collision.collider;
        if (hitCollider.gameObject.tag == "Player") //change this to find the grab zone
        {
            player.GainExp(value);
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) //gives exp
    {
        Debug.Log("exp hit");
        Collider2D hitCollider = collision;
        if (hitCollider.gameObject.tag == "Player") 
        {
            player.GainExp(value);
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        
    }
}
