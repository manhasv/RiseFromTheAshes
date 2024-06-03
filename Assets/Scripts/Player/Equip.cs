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
        if(LevelManager.hasGun && Input.GetKeyDown("1"))
        {
            if (Slot1.activeSelf)
            {
                Slot1.SetActive(false);
            }
            else
            {
                Slot1.SetActive(true);
            }
        }
    }
}
