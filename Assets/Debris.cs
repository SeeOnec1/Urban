using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [SerializeField] private float destroyDelay;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
