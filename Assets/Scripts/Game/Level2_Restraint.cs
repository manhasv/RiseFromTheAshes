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
            if (LevelManager.hasLv2Key)
            {
                text.text = "Press F to Open the Door!";
            } else {
                text.text = "You need to find the key to unlock the door! (Hint: Shoot the crates)";
            
            }
        } else {
            nearPlayer = false;
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F) && LevelManager.hasLv2Key)
        {
            LevelManager.level2 = true;
            SceneManager.LoadScene(sceneName);
        }
    }
}
