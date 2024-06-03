using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public int speed = 2;
    public int detectionRange = 10;
    public int damage = 2;
    private LevelManager levelManager;
    public int minDistance = 3;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        InvokeRepeating("DamagePlayer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange && Vector3.Distance(transform.position, player.transform.position) > minDistance)
        {
            transform.LookAt(player);
            var targetPosition = player.transform.position;
            //Vector3 targetPosition = new Vector3(player.position.x, 0, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }

    private void DamagePlayer()
    {   
        if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
        {
            player.GetComponent<PlayerBehavior>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBehavior player = collision.gameObject.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
