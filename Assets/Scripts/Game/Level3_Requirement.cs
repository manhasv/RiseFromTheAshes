using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_Requirement : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.level2) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
