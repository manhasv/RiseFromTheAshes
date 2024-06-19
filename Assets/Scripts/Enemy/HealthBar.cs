using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float enemyHealth = 5;

    public float currentHealth;
    public Slider healthSlider;
    public GameObject gold;
    public float chance;
    //public GameObject smoke; // For the particle system

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = enemyHealth;
        healthSlider.value = enemyHealth;
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth -= LevelManager.playerDamage;
            if(currentHealth <= 0)
            {
                if (Random.Range(0, 100) < chance)
                {
                    Instantiate(gold, transform.position, Quaternion.identity);
                }
                DestroyEnemy();
            }
        }
    }

    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
