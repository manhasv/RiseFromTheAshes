using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject cratePieces;
    public float explosionForce = 10f;
    public float explosionRadius = 5;
    private void OnCollisionEnter(Collision collision)
    {
        
        Transform currentCrate = gameObject.transform;

    
        GameObject pieces = Instantiate(cratePieces, currentCrate.position, currentCrate.rotation);

        Rigidbody[] rbPieces = pieces.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rb in rbPieces)
        {
            rb.AddExplosionForce(explosionForce, currentCrate.position, explosionRadius);
        }
        Destroy(gameObject);
    }
}
