using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//le weakpoint est un Proxy pour l'enemy
public class WeakPointEnemy : Enemy
{
    //objet original en ref
    public Enemy original;
    Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void FixedUpdate()
    {
        rb.velocity = Vector3.zero;

    }

    //renvoyez requetes
    public override void TakeDMG(int value)
    {
        original.TakeDMG(value * 3);
    }
}
