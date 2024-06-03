using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLootBehavior : MonoBehaviour
{
    public int healAmount = 5;
    public AudioClip lootSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(lootSFX, transform.position);
            gameObject.SetActive(false);
            var playerHealth = other.GetComponent<PlayerBehavior>();
            playerHealth.Heal(healAmount);
            Destroy(gameObject, 0.5f);
        }
    }
}
