using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public GameObject playerInteractButton;

    public bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.NPCIsInteracting = true;
                }
            }
        }

        if (isInteractable() && !isInteracting)
        {
            playerInteractButton.SetActive(true);
        }
        else
        {
            playerInteractButton.SetActive(false);
        }
    }

    public bool isInteractable()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return true;
            }

        }
        return false;
    }

}
