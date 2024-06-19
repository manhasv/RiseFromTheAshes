using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBehavior : MonoBehaviour
{
    public Transform player;
    public AudioClip pickupSFX;
    public ParticleSystem particleEffect;

    public float pickUpDistance = 4f;

    public float value = 1f;

    bool pickUpAble = false;
    // Start is called before the first frame update
    void Start()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= pickUpDistance)
        {
            pickUpAble = true;
            Debug.Log("Press F to pick up");
        }
        else
        {
            pickUpAble = false;
        }

        if (pickUpAble && Input.GetKeyDown(KeyCode.F))
        {
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
            Instantiate(particleEffect, transform.position, transform.rotation);
            player.GetComponent<PlayerBehavior>().AddGold(value);
            ItemPickup item = GetComponent<ItemPickup>();
            FindObjectOfType<InventoryManager>().AddItem(item.itemName, item.itemID, item.quantity, item.itemIcon);
            Destroy(gameObject);
            
        }
    }
}