using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public Text gameText;
    public Slider healthBar;
    public Text missionCompleteText;
    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;
    private float textDuration = 5f;
    private float textTimer = 0f;

    // Game Related data
    public static bool hasGun = false;
    public static float playerDamage = 1;
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool hasLv2Key = false;
    public static bool level3 = false;
    public static bool hasLv3Key = false;
    public static bool level4 = false;
    public static bool hasLv4Key = false;
    
    void Start()
    {
        isGameOver = false;
        missionCompleteText.gameObject.SetActive(false);
        gameText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (missionCompleteText.gameObject.activeSelf)
        {
            textTimer += Time.deltaTime;
            if (textTimer >= textDuration)
            {
                missionCompleteText.gameObject.SetActive(false);
                textTimer = 0f;
            }
        }
    }


    public void UpdateHealth(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public void MissionComplete()
    {
        missionCompleteText.text = "Mission Complete! Find the gate to the next level";
        missionCompleteText.gameObject.SetActive(true);
        textTimer = 0f;
    }

    public void LevelLost()
    {
        isGameOver = true;
        gameText.text = "GAME OVER!";
        gameText.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);

        Invoke("LoadCurrentLevel", 2);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWin()
    {
        isGameOver = true;
        gameText.text = "GAME WIN!";
        gameText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        AudioSource.PlayClipAtPoint(gameWonSFX, GameObject.FindGameObjectWithTag("Player").transform.position);
    }

}
