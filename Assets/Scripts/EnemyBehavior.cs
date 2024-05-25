using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public int enemyHealth = 5;
    public int enemyAttack = 1;
    public int enemySpeed = 2;
    public int detectionRange = 10;
   

    // Start is called before the first frame update
    void Start()
    {
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
            transform.position =
                Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //TODO: find projectile damage
            enemyHealth -= 1;
            CheckHealth();
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
