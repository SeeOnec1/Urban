using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private Timer timerScript;

    private bool gameFinished;

    private int peopleAlive;


    [SerializeField] private GameObject splusText;
    [SerializeField] private GameObject sText;
    [SerializeField] private GameObject aText;
    [SerializeField] private GameObject bText;
    [SerializeField] private GameObject cText;
    [SerializeField] private GameObject dText;
    [SerializeField] private GameObject eText;

    [SerializeField] private Animator anim;

    private void Start()
    {
        Time.timeScale = 1f;
        gameFinished = false;
        eText.SetActive(false);
        dText.SetActive(false);
        cText.SetActive(false);
        bText.SetActive(false);
        aText.SetActive(false);
        sText.SetActive(false);
        splusText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            gameFinished = true;
        }
    }

    private void Update()
    {
        if (gameFinished)
        {
            Time.timeScale = 0f;
            gameFinished = false;
            timerScript.PauseTimer();
            peopleAlive = timerScript.HowManyAlive();
            CheckScore();
            anim.SetTrigger("end");
            // Debug.Log("AHH");
        }
    }

    private void CheckScore()
    {

        if (peopleAlive == 0)
        {
            eText.SetActive(true);
            dText.SetActive(false);
            cText.SetActive(false);
            bText.SetActive(false);
            aText.SetActive(false);
            sText.SetActive(false);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 1)
        {
            eText.SetActive(false);
            dText.SetActive(true);
            cText.SetActive(false);
            bText.SetActive(false);
            aText.SetActive(false);
            sText.SetActive(false);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 2)
        {
            eText.SetActive(false);
            dText.SetActive(false);
            cText.SetActive(true);
            bText.SetActive(false);
            aText.SetActive(false);
            sText.SetActive(false);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 3)
        {
            eText.SetActive(false);
            dText.SetActive(false);
            cText.SetActive(false);
            bText.SetActive(true);
            aText.SetActive(false);
            sText.SetActive(false);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 4)
        {
            eText.SetActive(false);
            dText.SetActive(false);
            cText.SetActive(false);
            bText.SetActive(false);
            aText.SetActive(true);
            sText.SetActive(false);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 5)
        {
            eText.SetActive(false);
            dText.SetActive(false);
            cText.SetActive(false);
            bText.SetActive(false);
            aText.SetActive(false);
            sText.SetActive(true);
            splusText.SetActive(false);
        }
        else if (peopleAlive == 6)
        {
            eText.SetActive(false);
            dText.SetActive(false);
            cText.SetActive(false);
            bText.SetActive(false);
            aText.SetActive(false);
            sText.SetActive(false);
            splusText.SetActive(true);
        }


    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

}
