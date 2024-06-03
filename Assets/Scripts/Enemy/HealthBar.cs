using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float enemyHealth = 5;

    private float currentHealth;
    public Slider healthSlider;
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
            currentHealth -= 1;
            if(currentHealth <= 0)
            {
                DestroyEnemy();
            }
        }
    }

    private void DestroyEnemy()
    {
        //Instantiate(smoke, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
