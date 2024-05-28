using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public static float currentGold = 0;
    public static int currentHealth = 10;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.UpdateGold(currentGold);
        levelManager.UpdateHealth(currentHealth);
    }


    void Update()
    {
        if (transform.position.y < 0)
        {
            levelManager.LevelLost();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            //FindObjectOfType<LevelManager>().LevelLost();
            //Destroy(gameObject);
        }

    }

    public void AddGold(float amount)
    {
        currentGold += amount;
        levelManager.UpdateGold(currentGold);
        if (currentGold >= 5)
        {
            levelManager.MissionComplete();
        }
    }

    public void TakeDamage()
    {
        currentHealth--;
        levelManager.UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            levelManager.LevelLost();
        }
    }

}
