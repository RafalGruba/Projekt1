﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    // Time vars
    public TMP_Text timerText;
    private float startTime;
    public int countdownTime = 3;
    public TMP_Text countdownDisplay;
    private bool finished = false;
    private bool cdFinished = false;

    //Scene vars
    int currentSceneIndex;


    void Start()
    {
        StartCoroutine(CountdownToStart());
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (cdFinished)
        {
            if (finished == false)
            {
                float t = Time.time - startTime;
                string minutes = ((int)t / 60).ToString();
                string seconds = (t % 60).ToString("f2");
                timerText.text = minutes + ":" + seconds;
            }

        }
    }

    public void Finish()
    {
        timerText.color = Color.yellow;
        finished = true;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        cdFinished = true;
        startTime = Time.time;
        FindObjectOfType<Player>().CdFinished(); 
        countdownDisplay.gameObject.SetActive(false);
    }

}
