using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    public Transform player;
    public string sceneName;
    bool nearPlayer = false;
    public Text doorHint;
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
        if (Vector3.Distance(transform.position, player.position) <= 6)
        {
            doorHint.text = "Click F to teleport to " + sceneName;
            nearPlayer = true;
        } else {
            nearPlayer = false;
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
