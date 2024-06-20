using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_Mission : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelManager.level3 = true;
        FindObjectOfType<LevelManager>().MissionComplete();
    }
}
