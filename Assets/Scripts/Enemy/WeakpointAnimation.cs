using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakpointAnimation : MonoBehaviour
{

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.Rotate(0, 0, 90 * Time.deltaTime);

        float speedFactor = 3;
        float step = (Mathf.Sin(Time.time * speedFactor) + 1) / 2;

        rectTransform.localScale = Vector3.Lerp(Vector3.one / 100, new Vector3(1.5f, 1.5f, 1.5f) / 100, step);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            var bossHealth = FindObjectOfType<BossHealth>();
            bossHealth.TakeDamage(LevelManager.playerDamage);
            Destroy(other.gameObject);
        }
    }
}
