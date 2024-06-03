using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public static float currentGold = 0;
    public float startingHealth = 100;
    private static float currentHealth = 0;
    public Text goldText;
    public Slider healthBar;
    void Start()
    {
        
        if (currentHealth == 0)
        {
            currentHealth = startingHealth;
        }
        healthBar.maxValue = startingHealth;
        goldText.text = "Gold: " + currentGold;
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

    }

    public void AddGold(float amount)
    {
        currentGold += amount;
        goldText.text = "Gold: " + currentGold;
    }
    public void RemoveGold(float amount)
    {
        currentGold -= amount;
        goldText.text = "Gold: " + currentGold;
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
            Die();
            FindObjectOfType<LevelManager>().LevelLost();
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth < 100)
        {
            currentHealth += healAmount;
            healthBar.value = Mathf.Clamp(currentHealth, 0, 100);
            Debug.Log("Player health: " + currentHealth);
        }
    }

    void Die()
    {
        Debug.Log("Player is dead!");
        transform.Rotate(-90, 0, 0, Space.Self);
    }

}
