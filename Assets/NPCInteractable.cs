using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractable : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject NPCTextSystem;
    public string NpcName;

    public bool NPCIsInteracting = false;
    public GameObject player;

    public GameObject gateVFX;
    public GameObject wizardVFX;
    bool isDestroyed = false;
    bool isInteractable = true;

    public List<string> dialogues = new List<string>()
        {
            "Greetings, noble leader.",
            "I am Elowen, a humble servant of the arcane arts.",
            "Dark times have befallen our once-thriving village.",
            "The malevolent breed known as the 'Sable Reapers' has",
            "laid waste to our homes and hearths.",
            "Yet, hope remains, for you have returned.",
            "As the appointed guardian and leader of this village,",
            "it is upon your shoulders that the mantle of restoration now rests.",
            "Your first task is of utmost importance.",
            "Scattered across the forsaken grounds of the Abandoned Village lie five lost treasures, relics of our past glory and symbols of our resilience.",
            "Seek these treasures, and with their power, begin the arduous task of rebuilding our village.",
            "Go forth, brave leader, and may the light of wisdom guide your path.",
        };
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NPCIsInteracting)
        {
            Interact();

        }
    }

    public void Interact()
    {
        if (isInteractable)
        {
            player.GetComponent<PlayerInteract>().isInteracting = true;
            player.GetComponent<PlayerInteract>().playerInteractButton.SetActive(false);
            //player.GetComponent<CharacterController>().enabled = false;
            if (index < dialogues.Count)
            {
                NewDialogue(dialogues[index]);
                index += 1;
            }
            else
            {

                NPCIsInteracting = false;

                NPCTextSystem.SetActive(false);
                index = 0;
                player.GetComponent<PlayerInteract>().isInteracting = false;
                player.GetComponent<PlayerInteract>().playerInteractButton.SetActive(true);
                //player.GetComponent<CharacterController>().enabled = true;
                isInteractable = false;
                
                Destroy(gameObject, 0.5f);
                Instantiate(wizardVFX, transform.position, transform.rotation);
            }
        }

    }

    void NewDialogue(string next)
    {
        Debug.Log("Start Dialogue");
        dialogueText.text = next;
        nameText.text = NpcName;
        NPCTextSystem.SetActive(true);

    }
}
