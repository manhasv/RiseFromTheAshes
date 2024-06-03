using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject vial;
    public GameObject key;
    public bool hasKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if(hasKey)
            {
                Instantiate(key, transform.position, transform.rotation);
            } else {
                Instantiate(vial, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    
}
