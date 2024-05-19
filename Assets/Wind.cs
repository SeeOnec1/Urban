using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;

    [SerializeField] private WindZone windZone;
    [SerializeField] private Vector3 windDirection;
    [SerializeField] private float windForce;

    private bool canApplyForce;

    private float particleWindForce;

    private bool switchDirection;

    private void Start()
    {
        //windZone.windMain = windForce;
        switchDirection = true;
        particleWindForce = windZone.windMain;
    }

    private void Update()
    {
        if (switchDirection)
        {
            switchDirection = false;
            StartCoroutine(WindRando());
        }
    }

    private void FixedUpdate()
    {
        if (canApplyForce)
        {
            playerRB.AddForce(windDirection.normalized * windForce);
        }
    }

    IEnumerator WindRando()
    {
        float randoTime = 3;
        yield return new WaitForSeconds(randoTime);
        windDirection = new Vector3(-windDirection.x, 0, 0);
        particleWindForce = -particleWindForce;
        windZone.windMain = particleWindForce;
        switchDirection = true;
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
