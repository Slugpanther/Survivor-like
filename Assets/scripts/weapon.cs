using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour, IPoolable //probably make a interface?
{

    //apply the buffs to base stats of the weapon
    protected int lvl = 0;
    [SerializeField] int dmg;
    [SerializeField] public float baseTimer;
    [SerializeField] public float timer;
    [SerializeField] float scale;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float durationTimer = 5f; //lifespan
    [SerializeField] float timeAlive; //only for weapons that do something after x seconds other than destroy  

    public void Reset()
    {
        
    }
    public void LevelUpWeapon() //make it virtual when interface?
    {
        //define it in each specific weapon script
    }
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
        weapon.durationTimer -= Time.deltaTime;
            if(weapon.durationTimer <= 0){
                gameObject,setActive(false);
            }
    */


}
