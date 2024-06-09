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
        if (Vector3.Distance(transform.position, player.position) <= 4)
        {
            doorHint.gameObject.SetActive(true);
            doorHint.text = "Click F to teleport to " + sceneName;
            nearPlayer = true;
        } else {
            doorHint.gameObject.SetActive(false);
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F))
        {
            doorHint.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }
    }
}
