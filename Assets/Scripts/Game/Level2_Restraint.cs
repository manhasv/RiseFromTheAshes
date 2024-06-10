using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Restraint : MonoBehaviour
{
    public Transform player;
    bool nearPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 4)
        {
            nearPlayer = true;
        } else {
            nearPlayer = false;
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F) && LevelManager.level2)
        {
            FindObjectOfType<LevelManager>().LevelBeat();
        }
    }
}
