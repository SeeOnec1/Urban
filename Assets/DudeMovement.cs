using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DudeMovement : MonoBehaviour
{
    [Header("Parts Reference")]
    [SerializeField] private GameObject dudeTorso;
    [SerializeField] private GameObject dudeArmL;
    [SerializeField] private GameObject dudeArmR;

    [Header("MouseUpdates")]
    [SerializeField] private float armsRiseValue;
    [SerializeField] private float torsoRiseValue;

    private bool rightMouseHeld;
    private bool rightArmUp;

    private bool leftMouseHeld;
    private bool leftArmUp;

    private bool bothArmsHeld;
    private bool isClimbing;
    private bool firstStep;

    private void Start()
    {
        rightMouseHeld = false;
        leftMouseHeld = false;

        firstStep = true;
        isClimbing = false;
    }

    private void Update()
    {
        if (firstStep)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                rightMouseHeld = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                rightMouseHeld = false;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                leftMouseHeld = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                leftMouseHeld = false;
            }

            #region RaisingArms

            if (rightMouseHeld)
            {
                if (!rightArmUp)
                {
                    RightArmUp();
                }
            }
            else if (!rightMouseHeld)
            {
                if (rightArmUp)
                {
                    RightArmDown();
                }
            }
            else if (leftMouseHeld)
            {
                if (!leftArmUp)
                {
                    LeftArmUp();
                }
            }
            else if (!leftMouseHeld)
            {
                if (leftArmUp)
                {
                    LeftArmDown();
                }
            }

            #endregion

            //Debug.Log(leftMouseHeld + ", " + rightMouseHeld);

            if (!isClimbing)
            {
                if (rightMouseHeld)
                {
                    if (leftMouseHeld)
                    {
                        isClimbing = true;
                        RightMouseClimbFirst();
                    }
                }
                else if (leftMouseHeld)
                {
                    if (rightMouseHeld)
                    {
                        isClimbing = true;
                        LeftMouseClimbFirst();
                    }
                }
            }

            if (leftMouseHeld && rightMouseHeld && isClimbing)
            {
                if (!rightMouseHeld)
                {
                    isClimbing = false;
                }
                else if (!leftMouseHeld)
                {
                    isClimbing = false;
                }
            }

        }

        if (!firstStep)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                rightMouseHeld = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                rightMouseHeld = false;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                leftMouseHeld = true;
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                leftMouseHeld = false;
            }

            #region RaisingArms

            if (rightMouseHeld)
            {
                if (!rightArmUp)
                {
                    dudeArmR.transform.position =
                        new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y + armsRiseValue);
                    rightArmUp = true;
                }
            }
            if (!rightMouseHeld)
            {
                if (rightArmUp)
                {
                    dudeArmR.transform.position =
                        new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y);
                    rightArmUp = false;
                }

            }

            if (leftMouseHeld)
            {
                if (!leftArmUp)
                {
                    dudeArmL.transform.position =
                        new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y + armsRiseValue);
                    leftArmUp = true;
                }
            }
            if (!leftMouseHeld)
            {
                if (leftArmUp)
                {
                    dudeArmL.transform.position =
                        new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y);
                    leftArmUp = false;
                }
            }

            #endregion
        }





        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void LeftMouseClimbFirst()
    {
        dudeTorso.transform.position =
                            new Vector2(dudeTorso.transform.position.x, dudeTorso.transform.position.y + torsoRiseValue);

        dudeArmR.transform.position =
           new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y);

        dudeArmL.transform.position =
            new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y);


        //rightArmUp = true;
        //rightMouseHeld = false;
        //leftMouseHeld = true;
        firstStep = false;

        RightArmUp();
        LeftArmDown();
    }

    private void RightMouseClimbFirst()
    {
        dudeTorso.transform.position =
                            new Vector2(dudeTorso.transform.position.x, dudeTorso.transform.position.y + torsoRiseValue);

        dudeArmR.transform.position =
           new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y);

        dudeArmL.transform.position =
            new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y);


        //leftArmUp = true;
        //leftMouseHeld = false;
        //rightMouseHeld = true;
        firstStep = false;

        LeftArmUp();
        RightArmDown();
    }

    private void LeftArmUp()
    {
        dudeArmL.transform.position =
                        new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y + armsRiseValue);
        leftArmUp = true;
    }

    private void LeftArmDown()
    {
        dudeArmL.transform.position =
                        new Vector2(dudeArmL.transform.position.x, dudeArmL.transform.position.y - armsRiseValue);
        leftArmUp = false;
    }

    private void RightArmUp()
    {
        dudeArmR.transform.position =
                       new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y + armsRiseValue);
        rightArmUp = true;
    }

    private void RightArmDown()
    {
        dudeArmR.transform.position =
                       new Vector2(dudeArmR.transform.position.x, dudeArmR.transform.position.y - armsRiseValue);
        rightArmUp = false;
    }
}
