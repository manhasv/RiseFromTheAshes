using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldHInt : MonoBehaviour
{
    public Transform player;
    public float pickUpDistance = 4f;

    public Text hint;
    // Start is called before the first frame update
    void Start()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= pickUpDistance)
        {
            hint.text = "Press F to pick up gold";
        }
    }
}
