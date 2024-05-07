using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour, IPoolable //probably make a interface?
{

    //apply the buffs to base stats of the weapon
    protected int lvl = 0;
    [SerializeField] public int dmg;
    [SerializeField] public float baseTimer;
    [SerializeField] public float timer;
    [SerializeField] public float scale;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float durationTimer = 5f; //lifespan
    [SerializeField] float timeAlive; //only for weapons that do something after x seconds other than destroy  

    public void Reset()
    {

    }
    public void LevelUpWeapon() //make it virtual when interface?
    {
        //define it in each specific weapon script
        lvl++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D hitCollider = collision.collider;
        if (hitCollider.gameObject.tag == "Enemy")
        {
            Enemy hitEnemy = hitCollider.gameObject.GetComponent<Enemy>();
            hitEnemy.TakeDMG(dmg);
            Debug.Log("Damage");
        }
    }

    void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }
}
