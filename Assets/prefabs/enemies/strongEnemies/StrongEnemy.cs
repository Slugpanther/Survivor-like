using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : Enemy
{
    [SerializeField] GameObject weakpointPrefab;
    private WeakPointEnemy weakpoint;
    private LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        weakpoint = Instantiate(weakpointPrefab, transform.position, Quaternion.identity).GetComponent<WeakPointEnemy>();
        weakpoint.original = this;
        lineRenderer = weakpoint.GetComponent<LineRenderer>();
        UpdateLine();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateLine();
    }

    void UpdateLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
    }

    public override void Die()
    {
        weakpoint.Die();
        base.Die();
    }

}
