using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RogueEnemyAI : MonoBehaviour
{
    public enum FSMStates
    {
        Chase,
        Attack,
        Dead,
    }

    public FSMStates curState;
    public float chaseDistance = 10;
    public GameObject player;
    public float speed = 5;
    public float attackDistance = 3;
    HealthBar enemyHealth;
    float health;

    float distanceToPlayer;
    Vector3 nextDestination;
    float elapsedTime;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<HealthBar>();
        health = enemyHealth.currentHealth;
        elapsedTime = 0;
        Initialize();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        curState = FSMStates.Chase;    
    }

    void Update()
    {   
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);    
        switch(curState)
        {
            case FSMStates.Chase:
                UpdateChaseState();
                break;
            case FSMStates.Attack:
                UpdateAttackState();
                break;
            case FSMStates.Dead:
                UpdateDeadState();
                break;
        }

        elapsedTime += Time.deltaTime;
        health = enemyHealth.currentHealth;

        if (health <= 0)
        {
            curState = FSMStates.Dead;
        }
    }

    void UpdateChaseState()
    {
        nextDestination = player.transform.position;
        agent.stoppingDistance = attackDistance;
        agent.speed = 5f;
        if (distanceToPlayer <= attackDistance)
        {
            curState = FSMStates.Attack;
        } else if (distanceToPlayer > chaseDistance)
        {
            nextDestination =  transform.position;
        }
        FaceTarget(nextDestination);
        agent.SetDestination(nextDestination);
    }

    void UpdateAttackState()
    {
        nextDestination = player.transform.position;
        if (distanceToPlayer <= attackDistance)
        {
            curState = FSMStates.Attack;
        } else if (distanceToPlayer > attackDistance && distanceToPlayer <=chaseDistance)
        {
            curState = FSMStates.Chase;
        } else if (distanceToPlayer > chaseDistance)
        {
            nextDestination =  transform.position;
        }
        FaceTarget(nextDestination);
    }

    void UpdateDeadState()
    {
        Destroy(gameObject, 2);
    }

    void FaceTarget(Vector3 target) 
    {
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }
}
