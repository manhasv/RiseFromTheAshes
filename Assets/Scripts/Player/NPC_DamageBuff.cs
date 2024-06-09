using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC_DamageBuff : MonoBehaviour
{
    public Transform player;
    public float price = 50;
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
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) <= 4)
        {
            interactable = true;
            NPC_Text.gameObject.SetActive(true);
            NPC_Text.text = "Press F to pay " + price + " gold for 1 damage buff";
        }
        else
        {
            interactable = false;
            NPC_Text.gameObject.SetActive(false);
        }

        if (interactable && Input.GetKeyDown(KeyCode.F) && player.GetComponent<PlayerBehavior>().GetGold() >= price)
        {
            player.GetComponent<PlayerBehavior>().RemoveGold(price);
        }
    }
}
