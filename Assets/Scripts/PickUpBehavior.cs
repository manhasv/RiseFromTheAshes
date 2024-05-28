using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBehavior : MonoBehaviour
{
    public Transform player;
    public float pickUpDistance = 4f;

    public float value = 1f;

    bool pickUpAble = false;
    public Text gameAnnouncerText;
    // Start is called before the first frame update
    void Start()
    {
        gameAnnouncerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= pickUpDistance)
        {
            gameAnnouncerText.gameObject.SetActive(true);
            gameAnnouncerText.text = "Hit F to Pickup";
            pickUpAble = true;
        }
        else
        {
            gameAnnouncerText.gameObject.SetActive(false);
        }

        if (pickUpAble && Input.GetKeyDown(KeyCode.F))
        {
            gameAnnouncerText.gameObject.SetActive(false);
            Destroy(gameObject);
            player.GetComponent<PlayerBehavior>().AddGold(value);


        }
    }
}