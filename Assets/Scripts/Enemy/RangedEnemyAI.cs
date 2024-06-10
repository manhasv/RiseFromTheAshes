using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public enum FSMStates
    {
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    public FSMStates currentState;
    public int attackRange;
    public int detectionRange;
    public int enemySpeed;
    public Transform PatrolParent;

    [Header("Weapon Settings")]
    [Tooltip("Enemy's weapon")]
    public GameObject bulletPrefab;
    public float fireRate;
    public int bulletVelocity;
    

    Transform player;
    float distanceToPlayer;
    Vector3 nextDestination;
    Transform[] patrolPoints;
    int currentDestinationIndex = 0;
    HealthBar healthBar;
    float elapsedTime = 0;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = FSMStates.Patrol;
        healthBar = GetComponent<HealthBar>();
        patrolPoints = PatrolParent.GetComponentsInChildren<Transform>();
        FindNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case FSMStates.Patrol:
                UpdatePatrolState();
                break;
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

        if (healthBar.enemyHealth <= 0)
        {
            currentState = FSMStates.Dead;
        }
    }

    void UpdatePatrolState()
    {   

        if (Vector3.Distance(transform.position, nextDestination) < 1)
        {
            FindNextPoint();
        }
        else if (distanceToPlayer <= detectionRange)
        {
            currentState = FSMStates.Chase;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextDestination, enemySpeed * Time.deltaTime);
        FaceTarget(nextDestination);
    }

    void UpdateChaseState()
    {
        enemySpeed = 5;
        nextDestination = player.position;
        FaceTarget(nextDestination);

        transform.position = Vector3.MoveTowards(transform.position, nextDestination, enemySpeed * Time.deltaTime);

        if (distanceToPlayer > detectionRange)
        {
            currentState = FSMStates.Patrol;
            FindNextPoint();
        }
        else if (distanceToPlayer <= attackRange)
        {
            currentState = FSMStates.Attack;
        }
    }

    void UpdateAttackState()
    {
        nextDestination = player.position;
        FaceTarget(nextDestination);
        
        if (elapsedTime >= 1/fireRate)
        {
            // FIRE Projectile
            GameObject projectile = Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 1), transform.rotation);
            projectile.transform.SetParent(GameObject.Find("ProjectileParent").transform);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * bulletVelocity;
            elapsedTime = 0f;
        }

        if (distanceToPlayer > attackRange)
        {
            currentState = FSMStates.Chase;
        }
    }

    void UpdateDeadState()
    {
        print("dead");
    }

    void FindNextPoint()
    {
        nextDestination = patrolPoints[currentDestinationIndex].transform.position;

        currentDestinationIndex = (currentDestinationIndex + 1) % patrolPoints.Length;
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
