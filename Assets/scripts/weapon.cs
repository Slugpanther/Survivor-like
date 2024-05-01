using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour //probably make a struct
{

    //apply the buffs to base stats of the weapon

    [SerializeField] int dmg;
    [SerializeField] float baseTimer;
    [SerializeField] float timer;
    [SerializeField] float scale;
    [SerializeField] float projectileSpeed;
    [SerializeField] float durationTimer;
    [SerializeField] float timeAlive;
         
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D hitCollider = collision.collider;
        if (hitCollider.gameObject.tag == "Enemy")
        {
            enemy hitEnemy = hitCollider.gameObject.GetComponent<enemy>();
            hitEnemy.TakeDMG(dmg);
            Debug.Log("Damage");
        }
    }





    /* DESPAWN WEAPONS
        weapon.timeAlive -= Time.deltaTime;
            if(weapon.timeAlive <= 0){
                Destroy(gameobject);
            }
    */


}
