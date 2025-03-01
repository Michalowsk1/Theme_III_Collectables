using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
        Controls.upgrade = 0;
        Controls.upgradeCount = 0;
        Time.timeScale = 1;
    }

    public void PlayFromCheckPoint()
    {
        SceneManager.LoadScene("SampleScene");
        Controls.upgrade = 0;
        Controls.upgradeCount = 3;
        Time.timeScale = 1;
    }
}
