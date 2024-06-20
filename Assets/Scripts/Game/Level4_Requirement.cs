using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Requirement : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.level3) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }
}
