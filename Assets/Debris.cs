using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField] private float destroyDelay;
    private Rigidbody2D rb;

    private DudeMovement dudeMovement;
    private bool debrisHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        debrisHit = false;
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            rb = GetComponent<Rigidbody2D>();
            int rotationValue = Random.Range(1, 11);
            int rotationDirection = Random.Range(0, 2);

            if (rotationDirection == 0) { rb.AddTorque(rotationValue * 100); }
            else if (rotationDirection == 1) { rb.AddTorque(-rotationValue * 100); }

            StartCoroutine(DestroyDelay());
            debrisHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DebrisDestroy"))
        {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !debrisHit)
        {
            debrisHit = true;
            dudeMovement = collision.gameObject.GetComponent<DudeMovement>();
            dudeMovement.DebrisHit();
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
