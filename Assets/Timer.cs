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

    [SerializeField] private TextMeshProUGUI peopleAlive;
    private int numberOfPeopleAlive;

    private void Start()
    {
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        timerOn = false;
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

        if (timeToShow >= 150) numberOfPeopleAlive = 6;
        else if (timeToShow >= 120 && timeToShow < 150) numberOfPeopleAlive = 5;
        else if (timeToShow >= 90 && timeToShow < 120) numberOfPeopleAlive = 4;
        else if (timeToShow >= 60 && timeToShow < 90) numberOfPeopleAlive = 3;
        else if (timeToShow >= 30 && timeToShow < 60) numberOfPeopleAlive = 2;
        else if (timeToShow >= 0 && timeToShow < 30) numberOfPeopleAlive = 1;
        else if (timeToShow < 0) { numberOfPeopleAlive = 0; PauseTimer(); }

        peopleAlive.text = numberOfPeopleAlive.ToString();

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

    public int HowManyAlive()
    {
        return numberOfPeopleAlive;
    }
}
