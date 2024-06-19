using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Speeder : MonoBehaviour
{
    public Transform player;
    public float speedIncrease = 1;
    public float price = 10;
    private bool interactable;
    public Text NPC_Text;
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
        if (Vector3.Distance(transform.position, player.position) <= 4)
        {
            interactable = true;
            NPC_Text.text = "Press F to pay " + price + " gold for " + speedIncrease + " speed increase";
        }
        else
        {
            interactable = false;
        }

        if (interactable && Input.GetKeyDown(KeyCode.F) && player.GetComponent<PlayerBehavior>().GetGold() >= price)
        {
            player.GetComponent<PlayerBehavior>().RemoveGold(price);
            PlayerController.speed += speedIncrease;
        }
    }
}
