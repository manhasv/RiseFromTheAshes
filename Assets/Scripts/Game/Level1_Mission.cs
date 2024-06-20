using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Mission : MonoBehaviour
{
    private void OnDestroy()
    {
        if (!LevelManager.isGameOver) {
            LevelManager.level1 = true;
            FindObjectOfType<LevelManager>().MissionComplete();
        }
        
    }
}
