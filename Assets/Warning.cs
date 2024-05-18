using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    private GameObject debris;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        debris = GameObject.FindGameObjectWithTag("Debris");

        if (debris != null)
        {
            sr.enabled = true;
            transform.position =
                new Vector2(debris.transform.position.x, playerObject.transform.position.y);
        }
        else if (debris == null)
        {
            sr.enabled = false;
            transform.position =
           new Vector2(0, playerObject.transform.position.y);
        }
    }
}
