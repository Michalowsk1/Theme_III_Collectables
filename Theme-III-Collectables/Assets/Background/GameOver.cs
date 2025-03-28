using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject meteorSpawn;
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Controls.upgrade = 0;
        Controls.upgradeCount = 0;
        Time.timeScale = 1;
        LaserCharge.batteryLevel = 0;
        Controls.incValue = 0.05f;
    }

    public void PlayFromCheckPoint()
    {
        SceneManager.LoadScene("SampleScene");
        screen.SetActive(false);
        screen.SetActive(true);
        Controls.upgradeCount = 3;
        Time.timeScale = 1;
        gameOverText.SetActive(false);
        Controls.upgrade = 1;
       // bossBattle.timer = 0;
        LaserCharge.batteryLevel = 0;
        FinalScene.bossDefeated = false;
        meteorSpawn.SetActive(false);
        Controls.incValue = 0.05f;
    }

    //public void VictoryPlayAgain()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //    Controls.upgrade = 0;
    //    Controls.upgradeCount = 0;
    //    Time.timeScale = 1;
    //    FinalScene.bossDefeated= false;
    //    LaserCharge.batteryLevel = 0;
    //}

    //public void VictoryPlayFromCheckPoint()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //    screen.SetActive(false);
    //    screen.SetActive(true);
    //    Controls.upgradeCount = 3;
    //    Time.timeScale = 1;
    //    gameOverText.SetActive(false);
    //    Controls.upgrade = 1;
    //    //bossBattle.timer = 0;
    //    LaserCharge.batteryLevel = 0;
    //    meteorSpawn.SetActive(false);


    //}
}
