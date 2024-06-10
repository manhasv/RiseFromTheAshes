using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Mission : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelManager.level2 = true;
        FindObjectOfType<LevelManager>().MissionComplete();
    }
}
