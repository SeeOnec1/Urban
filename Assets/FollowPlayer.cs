using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float x;
    [SerializeField] private float y;

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x + x, player.transform.position.y + y);
    }
}
