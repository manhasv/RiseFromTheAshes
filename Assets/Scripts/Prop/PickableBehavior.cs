using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBehavior : MonoBehaviour
{
    public Transform player;

    public int pickableRange = 1;

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
        if (Vector3.Distance(transform.position, player.transform.position) <= pickableRange)
        {

        }
    }
}
