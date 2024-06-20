using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Requirement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (LevelManager.level1) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
