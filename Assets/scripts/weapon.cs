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
    [SerializeField] public int amount;
    [SerializeField] public float interval;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float durationTimer = 5f; //lifespan
    [SerializeField] float timeAlive; //only for weapons that do something after x seconds other than destroy  

    void Start()
    {
        //StartCoroutine(SpawnWeapon(this)); //watch out for this
    }


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

    public IEnumerator SpawnWeapon(Weapon weap)
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            //spawn weapon
            for (int i = 0; i < amount; i++)
            {
                //code to add weapon below
                yield return new WaitForSeconds(interval);
            }

        }
    }
}
