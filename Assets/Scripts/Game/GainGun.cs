using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GainGun : MonoBehaviour
{
    public Text text;
    public AudioClip lootSFX;
    //public GameObject trap;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.tag + "!");
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.hasGun = true;
            AudioSource.PlayClipAtPoint(lootSFX, transform.position);
            InformPlayer();
            Invoke("ClearText", 2f);
            //GameObject spawnedEnemy = Instantiate(trap, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject, 4f);
            

        }
    }

    private void InformPlayer()
    {
        text.gameObject.SetActive(true);
        text.text = "Press 1 to equip gun";
    }
    private void ClearText()
    {
        text.text = "";
        text.gameObject.SetActive(false);
    }
}
