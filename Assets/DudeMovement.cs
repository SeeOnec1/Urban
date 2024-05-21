using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DudeMovement : MonoBehaviour
{
    [SerializeField] private GameObject topHook;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private SpringJoint2D joint;

    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Wind wind;

    [SerializeField] private GameObject topHinge;

    private bool mouseOneHeld, mouseTwoHeld;
    private bool canPress;

    private bool isJumping;
    private int sway;

    private bool debrisHit;

    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator shadowAnim;


    private bool isPressingMouse;

    [SerializeField] private AudioSource climbSFX;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource jumpSFX;
    private bool sendJumpSFX;

    [Header("Camera Shake")]
    [SerializeField] private float shakeIntensity = 3f;
    [SerializeField] private float shakeTime = 0.23f;
    private GameObject cinemachineCamera;
    private CinemachineVirtualCamera vCam;
    CinemachineBasicMultiChannelPerlin cbmcp;

    private bool leftMouseButtonSimulated, rightMouseSimulated, bothButtonSimulated;
    private bool canEnd;

    private void Start()
    {
        lr.enabled = true;

        //joint.anchor = topHinge.transform.position;

        joint.connectedAnchor = topHinge.transform.position;

        joint.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

        canPress = true;
        isJumping = false;
        sway = 0;

        boxCollider.enabled = true;

        leftMouseButtonSimulated = false;
        rightMouseSimulated = false;
        canEnd = false;

        #region CameraShake
        cinemachineCamera = GameObject.FindGameObjectWithTag("Cinemachine");
        vCam = cinemachineCamera.GetComponent<CinemachineVirtualCamera>();
        cbmcp = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0;
        #endregion
    }

    private void Update()
    {

        /*
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x <= 1080)
                {
                    canEnd = true;
                    leftMouseButtonSimulated = false;
                    rightMouseSimulated = true;

                }

                if (touch.position.x > 1080)
                {
                    canEnd = true;
                    rightMouseSimulated = false;
                    leftMouseButtonSimulated = true;
                }


            }
            else if (touch.phase == TouchPhase.Ended && canEnd)
            {
                canEnd = false;
                leftMouseButtonSimulated = false;
                rightMouseSimulated = false;
            }


        }

        if (Input.touchCount == 2)
        {
            //Touch touch = Input.GetTouch(0);


            bothButtonSimulated = true;
        }
        else bothButtonSimulated = false;
        */



        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, topHook.transform.position);

        //joint.anchor = new Vector2(topHinge.transform.position.x, topHinge.transform.position.y - transform.position.y);
        joint.connectedAnchor = topHinge.transform.position;

        if (debrisHit)
        {
            rb.gravityScale = 1;
            mouseOneHeld = false;
            mouseTwoHeld = false;
            wind.NoWind();
            isJumping = false;
            // boxCollider.enabled = false;
            playerAnim.SetBool("isFalling", true);
        }
        else
        {
            playerAnim.SetBool("isFalling", false);
        }

        #region Phone Controls
        /*
        if (rightMouseSimulated) //leftside
        {
            if (canPress)
            {

                joint.enabled = false;
                rb.gravityScale = 0f;
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                //rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
                wind.NoWind();

                //Debug.Log("shouldGoDown");
                isPressingMouse = true;
            }
            mouseTwoHeld = true;
        }

        if (!rightMouseSimulated)
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();

                isPressingMouse = false;
            }
            mouseTwoHeld = false;
        }

        if (leftMouseButtonSimulated)
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
                wind.NoWind();

                isPressingMouse = true;
            }
            mouseOneHeld = true;
        }

        if (!leftMouseButtonSimulated)
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();

                isPressingMouse = false;
            }

            mouseOneHeld = false;
        }


        if (bothButtonSimulated && canPress)
        {
            //Debug.Log("complicated");
            isJumping = true;
            joint.enabled = true;
            canPress = false;
            wind.ApplyWind();
            //
        }
        else if (!bothButtonSimulated)
        {

            //Debug.Log("SwayToZero");
            if (!canPress && !debrisHit)
            {
                leftMouseButtonSimulated = false;
                rightMouseSimulated = false;
                isJumping = false;
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();
                canPress = true;
                sendJumpSFX = false;
                //playerAnim.SetBool("isJumping", false);
            }

        }*/
        #endregion

        #region PC controls
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
                wind.NoWind();

                isPressingMouse = true;
            }


            mouseOneHeld = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();


                isPressingMouse = false;
            }

            mouseOneHeld = false;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
                wind.NoWind();

                isPressingMouse = true;
            }

            mouseTwoHeld = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();

                isPressingMouse = false;
            }

            mouseTwoHeld = false;
        }


        if (mouseOneHeld && mouseTwoHeld && canPress)
        {
            //Debug.Log("complicated");
            isJumping = true;
            joint.enabled = true;
            canPress = false;
            wind.ApplyWind();
            //
        }
        else if (!mouseOneHeld || !mouseTwoHeld)
        {

            //Debug.Log("SwayToZero");
            if (!canPress && !debrisHit)
            {
                isJumping = false;
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();
                canPress = true;
                sendJumpSFX = false;
                //playerAnim.SetBool("isJumping", false);
            }

        }
        //Debug.Log(isJumping);

        #endregion



        if (isPressingMouse && canPress && Mathf.Abs(rb.velocity.y) > 0.1f)
        {

            playerAnim.SetBool("isMoving", true);
            climbSFX.volume = 0.6f;
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
            climbSFX.volume = 0f;
        }

        if (isJumping)
        {
            playerAnim.SetBool("isJumping", true);
            shadowAnim.SetBool("showShadow", true);
        }
        else if (!isJumping)
        {
            playerAnim.SetBool("isJumping", false);
            shadowAnim.SetBool("showShadow", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


        if (!sendJumpSFX && isJumping)
        {
            sendJumpSFX = true;
            jumpSFX.Play();
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        sway = 1;
        yield return new WaitForSeconds(2f);
        sway = 2;
    }

    private void SwayToZero()
    {
        isJumping = false;
        //Debug.Log("SwayToZero");
        joint.enabled = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        wind.NoWind();
        canPress = true;
        sway = 0;
    }

    public void DebrisHit()
    {
        hitSFX.Play();
        StartCoroutine(DebrisHitDamage());
    }

    IEnumerator DebrisHitDamage()
    {
        debrisHit = true;
        canPress = false;
        joint.enabled = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 1;
        mouseOneHeld = false;
        mouseTwoHeld = false;
        wind.NoWind();
        //boxCollider.enabled = false;

        yield return new WaitForSeconds(1f);

        joint.enabled = true;
        rb.gravityScale = 0;
        debrisHit = false;
        canPress = true;
        // boxCollider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            StartCoroutine(CameraShake());
        }
    }

    #region CamShake
    IEnumerator CameraShake()
    {
        cbmcp.m_AmplitudeGain = shakeIntensity;
        yield return new WaitForSeconds(shakeTime);

        cbmcp.m_AmplitudeGain = 0;
    }
    #endregion
}

