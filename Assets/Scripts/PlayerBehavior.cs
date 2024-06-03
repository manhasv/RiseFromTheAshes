using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public static float currentGold = 0;
    public float startingHealth = 20;
    private float currentHealth;
    public float passingGold = 30;
    public Text goldText;
    public Slider healthBar;
    void Start()
    {
        startingHealth = 100;
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        if (currentGold > 0) {
            goldText.text = "Gold: " + currentGold;
        } else {
            goldText.text = "Gold: 0";
        }
    }

    void Update()
    {
        if (transform.position.y < -50)
        {
            FindObjectOfType<LevelManager>().LevelLost();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     TakeDamage(1);
        // }

    }

    public void AddGold(float amount)
    {
        currentGold += amount;
        goldText.text = "Gold: " + currentGold;
        //FindObjectOfType<LevelManager>().UpdateGold(currentGold);
        if (currentGold >= passingGold)
        {
            FindObjectOfType<LevelManager>().MissionComplete();
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0) 
        {
            currentHealth -= damage;
            healthBar.value = currentHealth;
        } 
        if (currentHealth <= 0) {
            healthBar.value = 0;
        }
        Debug.Log("Current Health: " + currentHealth);
        //FindObjectOfType<LevelManager>().UpdateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelManager>().LevelLost();
        }
    }

}
