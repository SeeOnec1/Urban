using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private bool gameStarted;

    [SerializeField] private DudeMovement dudeMovement;
    [SerializeField] private Wind windScript;
    [SerializeField] private Timer timer;
    [SerializeField] private Animator panelAnim;

    [SerializeField] private CanvasGroup UI;

    [SerializeField] private AudioSource music;

    private void Awake()
    {
        gameStarted = false;

        dudeMovement.enabled = false;
        windScript.enabled = false;

        UI.interactable = false;
        UI.alpha = 0f;

        music.Stop();

    }

    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                gameStarted = true;
                panelAnim.SetTrigger("turnPanelOff");
                dudeMovement.enabled = true;
                windScript.enabled = true;

                UI.alpha = 1f;
                UI.interactable = true;

                timer.TimerOn();
                music.Play();

            }
        }
    }



    //gives player control
    //starts wind script
    //starts timer
}
