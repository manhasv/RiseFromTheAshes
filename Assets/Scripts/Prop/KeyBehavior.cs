using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public AudioClip lootSFX;

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

            //DoorBehavior.hasKey = true;

            Destroy(gameObject, 0.5f);
        }
    }
}
