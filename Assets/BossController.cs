using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public enum FSMStates
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    public FSMStates currentState;

    public float chaseDistance = 30;
    public float attackDistance = 3;
    public GameObject player;
    public float attackRate = 2;
    public GameObject deadVFX;
    public GameObject projectilePrefab;
    public float projectileVelocity;


    Vector3[] wanderPoints = new Vector3[3];
    Vector3 nextDestination;
    Animator anim;
    float distanceToPlayer;
    float elapsedTime = 0;

    BossHealth bossHealth;
    int health;
    int currentDestinationIndex = 0;
    bool isDead;

    NavMeshAgent agent;

    public Transform enemyEyes;
    public Transform attackingHand;
    public float fieldOfView = 100f;
    public GameObject[] weakpoints;

    void Start()
    {
        bossHealth = GetComponent<BossHealth>();
        health = bossHealth.currentHealth;
        isDead = false;

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        CreateWanderPoints();
        ShuffleWeakpoints();

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        currentState = FSMStates.Patrol;
        FindNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        health = bossHealth.currentHealth;

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
        elapsedTime += Time.deltaTime;

        if (health <= 0)
        {
            currentState = FSMStates.Dead;
        }
    }

    void CreateWanderPoints()
    {
        wanderPoints[0] = transform.position + Vector3.forward * 10;
        wanderPoints[1] = transform.position + Vector3.right * 10;
        wanderPoints[2] = transform.position + Vector3.left * 10;
    }

    public void ShuffleWeakpoints()
    {
        foreach (GameObject wkpt in weakpoints)
        {
            if (wkpt.activeInHierarchy)
            {
                wkpt.SetActive(false);
            }
        }

        int index = Random.Range(0, weakpoints.Length);
        weakpoints[index].SetActive(true);
    }

    // PATROL STATE - Player not in sight
    void UpdatePatrolState()
    {
        print("Patrolling");

        anim.SetInteger("animState", 1);

        agent.stoppingDistance = 1;

        agent.speed = 3.5f;

        Vector3 targetPosition = new Vector3(nextDestination.x, transform.position.y, nextDestination.z);

        agent.SetDestination(targetPosition);
        FaceTarget(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) <= agent.stoppingDistance)
        {
            FindNextPoint();
        }
        else if (IsPlayerInClearFOV())
        {
            currentState = FSMStates.Chase;
        }
    }

    // CHASE STATE - Player is within view
    void UpdateChaseState()
    {
        print("Chasing");

        anim.SetInteger("animState", 2);

        nextDestination = player.transform.position;

        agent.stoppingDistance = attackDistance;

        agent.speed = 5;

        agent.SetDestination(nextDestination);

        if (distanceToPlayer <= attackDistance)
        {
            currentState = FSMStates.Attack;
        }
        else if (distanceToPlayer >= chaseDistance)
        {
            FindNextPoint();
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);
    }

    #region ATTACK STATE
    void UpdateAttackState()
    {
        print("Attacking");

        nextDestination = player.transform.position;

        agent.stoppingDistance = attackDistance;


        if (distanceToPlayer <= attackDistance)
        {
            currentState = FSMStates.Attack;
        }
        else if (distanceToPlayer > attackDistance && distanceToPlayer <= chaseDistance)
        {
            currentState = FSMStates.Chase;
        }
        else if (distanceToPlayer > chaseDistance)
        {
            currentState = FSMStates.Patrol;
        }

        FaceTarget(nextDestination);

        anim.SetInteger("animState", 3);

        if (!LevelManager.isGameOver)
        {
            AttackBehavior();
        }
    }

    void AttackBehavior()
    {
        if (elapsedTime >= attackRate)
        {
            var animDuration = anim.GetCurrentAnimatorStateInfo(0).length;

            Invoke("ShootProjectile", animDuration);
            elapsedTime = 0.0f;
        }
    }

    void ShootProjectile()
    {
            // FIRE Projectile
            GameObject projectile = Instantiate(projectilePrefab, attackingHand.position, transform.rotation);
            projectile.transform.SetParent(GameObject.Find("ProjectileParent").transform);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = (player.transform.position - attackingHand.position) * projectileVelocity;
    }
    #endregion

    void UpdateDeadState()
    {
        anim.SetInteger("animState", 4);
        isDead = true;
        agent.SetDestination(transform.position);

        Destroy(gameObject, 4);
    }

    void FindNextPoint()
    {
        nextDestination = wanderPoints[currentDestinationIndex];

        currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;

        agent.SetDestination(nextDestination);
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(deadVFX, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackDistance);

        Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Vector3 frontRayPoint = enemyEyes.position + (enemyEyes.forward * chaseDistance);
        Vector3 leftRayPoint = Quaternion.Euler(0, fieldOfView * 0.5f, 0) * frontRayPoint;
        Vector3 rightRayPoint = Quaternion.Euler(0, -fieldOfView * 0.5f, 0) * frontRayPoint;

        Debug.DrawLine(enemyEyes.position, frontRayPoint, Color.cyan);
        Debug.DrawLine(enemyEyes.position, leftRayPoint, Color.yellow);
        Debug.DrawLine(enemyEyes.position, rightRayPoint, Color.yellow);
    }

    bool IsPlayerInClearFOV()
    {

        RaycastHit hit;

        Vector3 directionToPlayer = player.transform.position - enemyEyes.position;

        if (Vector3.Angle(directionToPlayer, enemyEyes.forward) <= fieldOfView)
        {
            if (Physics.Raycast(enemyEyes.position, directionToPlayer, out hit, chaseDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    print("Player in sight!");
                    return true;
                }
                return false;
            }
            return false;
        }
        return false;
    }
}
