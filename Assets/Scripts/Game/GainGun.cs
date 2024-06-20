using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainGun : MonoBehaviour
{
    public Text text;
    public AudioClip lootSFX;
    public Text hintText;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.tag + "!");
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.hasGun = true;
            LevelManager.level1 = true;
            AudioSource.PlayClipAtPoint(lootSFX, transform.position);
            InformPlayer();
            Invoke("ClearText", 2f);
            Destroy(gameObject, 4f);
            

        }
    }

    private void InformPlayer()
    {
        text.gameObject.SetActive(true);
        text.text = "Press E to equip gun";
        hintText.text = "There is a hidden door to the next level. Find it!";
    }
    private void ClearText()
    {
        text.text = "";
        text.gameObject.SetActive(false);
    }
}
