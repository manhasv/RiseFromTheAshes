using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Heal : MonoBehaviour
{
    public Transform player;
    public int healAmount = 10;
    public float price = 1;
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
            NPC_Text.gameObject.SetActive(true);
            NPC_Text.text = "Press F to pay " + price + " gold for " + healAmount + " HP";
        }
        else
        {
            interactable = false;
            NPC_Text.gameObject.SetActive(false);
        }

        if (interactable && Input.GetKeyDown(KeyCode.F))
        {
            player.GetComponent<PlayerBehavior>().RemoveGold(price);
            player.GetComponent<PlayerBehavior>().Heal(healAmount);
        }
    }
}
