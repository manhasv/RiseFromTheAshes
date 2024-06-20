using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level4_Restraint : MonoBehaviour
{
    public Transform player;
    bool nearPlayer = false;
    public Text text;
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
            Debug.Log("Player is near the door");
            nearPlayer = true;
            if (LevelManager.hasLv4Key)
            {
                text.text = "Press F to Escape the Dungeon!";
            } else {
                text.text = "You need to defeat the King to unlock this door!";
            
            }
        } else {
            nearPlayer = false;
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F) && LevelManager.hasLv4Key)
        {
            LevelManager.level4 = true;
            FindObjectOfType<LevelManager>().GameWin();
        }
    }
}
