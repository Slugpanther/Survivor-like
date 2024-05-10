using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//le weakpoint est un Proxy pour l'enemy
public class WeakPointEnemy : Enemy
{
    //objet original en ref
    public Enemy original;

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
