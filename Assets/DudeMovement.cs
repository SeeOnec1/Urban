using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

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
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, topHook.transform.position);

        //joint.anchor = new Vector2(topHinge.transform.position.x, topHinge.transform.position.y - transform.position.y);
        joint.connectedAnchor = topHinge.transform.position;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canPress)
            {
                joint.enabled = false;
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
                wind.NoWind();
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
            }

            mouseTwoHeld = false;
        }


        if (mouseOneHeld && mouseTwoHeld && canPress)
        {
            Debug.Log("complicated");
            //isJumping = true;
            joint.enabled = true;
            canPress = false;
            wind.ApplyWind();
        }
        else if (!mouseOneHeld || !mouseTwoHeld)
        {
            //isJumping = false;
            //Debug.Log("SwayToZero");
            if (!canPress && !debrisHit)
            {
                joint.enabled = false;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                wind.NoWind();
                canPress = true;
            }

        }



        /*
        if (mouseOneHeld && mouseTwoHeld && !isJumping)
        {
            isJumping = true;

            StartCoroutine(Jump());
        }

        if (isJumping)
        {
            if (sway == 1)
            {
                joint.enabled = true;
                canPress = false;
                wind.ApplyWind();
            }

            if (sway == 2)
            {
                //Debug.Log(sway);
                SwayToZero();
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
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
        debrisHit = true;
        canPress = false;
        StartCoroutine(DebrisHitDamage());
    }

    IEnumerator DebrisHitDamage()
    {
        joint.enabled = false;
        rb.gravityScale = 1;
        wind.NoWind();

        yield return new WaitForSeconds(1f);

        joint.enabled = true;
        rb.gravityScale = 0;
        debrisHit = false;
        canPress = true;
    }
}
