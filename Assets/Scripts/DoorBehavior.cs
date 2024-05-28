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
    public Text gameAnnouncerText;
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
            gameAnnouncerText.gameObject.SetActive(true);
            gameAnnouncerText.text = "Click F to teleport to first floor";
            nearPlayer = true;
        } else {
            gameAnnouncerText.gameObject.SetActive(false);
        }

        if (nearPlayer && Input.GetKeyDown(KeyCode.F))
        {
            gameAnnouncerText.gameObject.SetActive(false);
            //Load lv1 scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
