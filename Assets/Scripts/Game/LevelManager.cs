using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public Text gameText;
    public Text goldText;
    public Slider healthBar;
    public Text missionCompleteText;
    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;
    private float textDuration = 5f;
    private float textTimer = 0f;
    public static bool level2Key = false;
    public static bool hasGun = false;
    void Start()
    {
        isGameOver = false;
        missionCompleteText.gameObject.SetActive(false);
        gameText.gameObject.SetActive(false);
        //StartCoroutine(DisplayText());
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

    public void UpdateGold(float currentGold)
    {
        goldText.text = "Your Gold: " + currentGold;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    public void MissionComplete()
    {
        missionCompleteText.text = "Mission Complete! You can return to the village!";
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

    public void LevelBeat()
    {
        isGameOver = true;
        gameText.text = "GAME Win!";
        gameText.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameWonSFX, GameObject.FindGameObjectWithTag("Player").transform.position);
    }

}
