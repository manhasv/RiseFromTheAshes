using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBehavior : MonoBehaviour
{
    public Transform player;
    public float pickUpDistance = 2f;

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
            gameAnnouncerText.text = "Hit Pickup";
        } else {
            gameAnnouncerText.gameObject.SetActive(false);
        }
    }
}
