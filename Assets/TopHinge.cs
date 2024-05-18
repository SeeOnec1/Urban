using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHinge : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        transform.position = new Vector2(0, player.transform.position.y + 20f);
    }
}
