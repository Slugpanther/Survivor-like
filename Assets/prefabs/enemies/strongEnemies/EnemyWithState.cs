using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class StateMachine
{
    public Enemy enemy;
    Dictionary<string, State> states = new();
    State currentState;
    public void AddState(State state)
    {
        state.stateMachine = this;
        if (currentState == null)
        {
            currentState = state;
            currentState.OnStateEnter();
        }
        states.Add(state.GetType().Name, state);
    }

    public void Transition(string stateName)
    {
        currentState = states[stateName];
    }
    public void Transition<T>() where T : State
    {
        currentState = states[typeof(T).Name];
        currentState.OnStateEnter();
    }

    internal void Update()
    {
        currentState.OnStateUpdate();
    }
}

public abstract class State
{
    public StateMachine stateMachine;

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();



}

public class ChasingState : State
{
    public override void OnStateEnter()
    {
        Debug.Log("Chasing");
        stateMachine.enemy.moveSpeed = 1f;
    }
    public override void OnStateUpdate()
    {
        if (Vector3.Distance(stateMachine.enemy.transform.position, Player.GetInstance().transform.position) < 2f) //3f is the range
        {
            stateMachine.Transition<AttackingState>();
        }
    }
}
public class CooldownState : State
{
    float timer;
    public override void OnStateEnter()
    {
        Debug.Log("Cooldown");
        timer = 4f;
        stateMachine.enemy.moveSpeed = -1f;
    }
    public override void OnStateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.Transition<ChasingState>();
        }
    }
}
public class AttackingState : State
{
    float timer;
    public override void OnStateEnter()
    {
        Debug.Log("Attacking");
        //stateMachine.enemy.spriteRenderer.color = Color.blue;
        timer = 0.5f;
        stateMachine.enemy.Attack();
        stateMachine.enemy.moveSpeed = 0f;
    }
    public override void OnStateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.Transition<CooldownState>();
        }
    }
}





public class EnemyWithState : Enemy
{
    [SerializeField] GameObject projectile;
    StateMachine stateMachine = new();
    // Start is called before the first frame update
    void Start()
    {
        stateMachine.enemy = this;
        stateMachine.AddState(new ChasingState());
        stateMachine.AddState(new AttackingState());
        stateMachine.AddState(new CooldownState());
    }
    private void Update()
    {
        stateMachine.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

    }
    public override void Attack()
    {
        GameObject wpProjectile = ObjectPool.GetInstance().GetPooledObject(projectile); //gets anything from the pool
        wpProjectile.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        wpProjectile.SetActive(true);
    }
}
