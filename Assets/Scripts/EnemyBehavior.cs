using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public int enemyHealth = 5;
    public int enemySpeed = 2;
    public int detectionRange = 10;
    public int damage = 2;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = enemySpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            transform.LookAt(player);
            Vector3 targetPosition = new Vector3(player.position.x, 0, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }

    }

    private void DamagePlayer()
    {   
        if (Vector3.Distance(transform.position, player.transform.position) <= 1)
        {
            player.GetComponent<PlayerBehavior>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Projectile"))
        // {
        //     //TODO: find projectile damage
        //     enemyHealth -= 1;
        //     CheckHealth();
        // }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBehavior player = collision.gameObject.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    private void CheckHealth()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
