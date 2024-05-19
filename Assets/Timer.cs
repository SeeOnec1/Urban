using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private bool timerOn;
    private float timeRemaining, timeToShow;
    private TextMeshProUGUI timerText;

    [SerializeField] private float startTime;

    private void Start()
    {
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        timerOn = true;
        //timeRemaining = PlayerPrefs.GetFloat("timeYet");
        timeToShow = startTime;
        timeRemaining = 0;


        float min = Mathf.FloorToInt(timeRemaining / 60);
        float sec = Mathf.FloorToInt(timeRemaining % 60);
        PlayerPrefs.SetFloat("timeYet", timeRemaining);
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);

    }

    private void Update()
    {
        if (timerOn)
        {
            timeRemaining += Time.deltaTime;

            timeToShow = startTime - timeRemaining;

            float min = Mathf.FloorToInt(timeToShow / 60);
            float sec = Mathf.FloorToInt(timeToShow % 60);
            //PlayerPrefs.SetFloat("timeYet", timeRemaining);
            timerText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            timerOn = false;
        }

    }

    public void PauseTimer()
    {
        timerOn = false;
    }

    public void RestartRun()
    {
        timerOn = false;
        SceneManager.LoadScene(0);
    }

    public void TimerOn()
    {
        timerOn = true;
    }
}
