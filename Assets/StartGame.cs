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

    private void Awake()
    {
        gameStarted = false;

        dudeMovement.enabled = false;
        windScript.enabled = false;

        UI.interactable = false;
        UI.alpha = 0f;

    }

    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameStarted = true;
                panelAnim.SetTrigger("turnPanelOff");
                dudeMovement.enabled = true;
                windScript.enabled = true;

                UI.alpha = 1f;
                UI.interactable = true;

                timer.TimerOn();
            }
        }
    }



    //gives player control
    //starts wind script
    //starts timer
}
