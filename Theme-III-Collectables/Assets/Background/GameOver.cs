using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        //Controls.score = 0;
        //Screwdriver.count = 0;
        //GasPipe.count = 0;
        //fuelTank.count = 0;
        SceneManager.LoadScene("SampleScene");
        Controls.upgrade = 0;
        Time.timeScale = 1;
    }
}
