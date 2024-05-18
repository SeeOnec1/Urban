using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ps;

    private void Update()
    {
        if (player.transform.position.y < 7.46f)
        {
            gameObject.transform.position = new Vector3(0f, 0f, -10f);
            ps.transform.position = new Vector2(0, 10f);
        }
        else if (player.transform.position.y > 7.46f)
        {
            gameObject.transform.position = new Vector3(0f, 16.2f, -10f);
            ps.transform.position = new Vector2(0, 28f);
        }
    }
}
