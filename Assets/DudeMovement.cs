using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        lr.enabled = true;

        joint.anchor = topHinge.transform.position;

        joint.connectedAnchor = topHinge.transform.position;



        joint.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, topHook.transform.position);

        joint.anchor = new Vector2(topHinge.transform.position.x, topHinge.transform.position.y - transform.position.y);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            joint.enabled = false;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
            wind.NoWind();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            joint.enabled = false;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            wind.NoWind(); ;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            joint.enabled = true;
            wind.ApplyWind();
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            joint.enabled = false;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            wind.NoWind();
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
