using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2_Restraint : MonoBehaviour
{
    public Transform player;
    bool nearPlayer = false;
    public string sceneName;
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
            nearPlayer = true;
            if (LevelManager.level2)
            {
                text.text = "Press F to Win the Game!";
            } else {
                text.text = "You need to defeat the king to unlock the door!";
            
            }
        } else {
            nearPlayer = false;
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F) && LevelManager.level2)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
