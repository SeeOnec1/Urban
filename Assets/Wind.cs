using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;

    [SerializeField] private WindZone windZone;
    [SerializeField] private Vector3 windDirection;
    [SerializeField] private float windForce;

    private bool canApplyForce;

    private void Start()
    {
        //windZone.windMain = windForce;
    }

    private void FixedUpdate()
    {
        if (canApplyForce)
        {
            playerRB.AddForce(windDirection.normalized * windForce);
        }
    }

    public void NoWind()
    {
        canApplyForce = false;
    }
    public void ApplyWind()
    {
        canApplyForce = true;
    }

}
