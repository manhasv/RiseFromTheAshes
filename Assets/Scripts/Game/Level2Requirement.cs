using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Requirement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (LevelManager.level2) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
