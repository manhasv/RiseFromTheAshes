using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider healthBar;

    public float maxHealth = 200;
    public float currentHealth;
    public GameObject key;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        var bossController = FindObjectOfType<BossController>();
        bossController.ShuffleWeakpoints();
    }

    private void OnDestroy()
    {
        Instantiate(key, transform.position, Quaternion.identity);
    }
}
