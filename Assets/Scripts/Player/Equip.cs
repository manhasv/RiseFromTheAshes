using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public GameObject Slot1;
    // public GameObject Slot2;
    // public GameObject Slot3;

    // Start is called before the first frame update
    void Start()
    {
        Slot1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.hasGun && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Try to equip gun");
            if (Slot1.activeSelf)
            {
                Debug.Log("Gun is equipped");
                Slot1.SetActive(false);
            }
            else
            {
                Debug.Log("Gun is not equipped");
                Slot1.SetActive(true);
            }
        }
    }
}
