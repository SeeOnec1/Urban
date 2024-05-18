using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ps;

    private void Update()
    {
        if (player.transform.position.y < 7.5f) //1
        {
            gameObject.transform.position = new Vector3(0f, 0f, -10f);
            ps.transform.position = new Vector2(0, 10f);
        }
        else if (player.transform.position.y > 7.5f && player.transform.position.y < 23.68f) //2
        {
            gameObject.transform.position = new Vector3(0f, 16.2f, -10f);
            ps.transform.position = new Vector2(0, 27.2f);
        }
        else if (player.transform.position.y > 23.68f && player.transform.position.y < 39.84f) //3
        {
            gameObject.transform.position = new Vector3(0f, 2 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 43.1f);
        }
        else if (player.transform.position.y > 39.84f && player.transform.position.y < 56f) //4
        {
            gameObject.transform.position = new Vector3(0f, 3 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 58.7f);
        }
        else if (player.transform.position.y > 56f && player.transform.position.y < 72f) //5
        {
            gameObject.transform.position = new Vector3(0f, 4 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 74.6f);
        }
        else if (player.transform.position.y > 72f && player.transform.position.y < 88.4f) //6
        {
            gameObject.transform.position = new Vector3(0f, 5 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 90.8f);
        }
        else if (player.transform.position.y > 88.4f && player.transform.position.y < 104.6f) //7
        {
            gameObject.transform.position = new Vector3(0f, 6 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 106.7f);
        }
        else if (player.transform.position.y > 104.6f && player.transform.position.y < 120.8f) //8
        {
            gameObject.transform.position = new Vector3(0f, 7 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 123.15f);
        }
        else if (player.transform.position.y > 120.8f && player.transform.position.y < 137f) //9
        {
            gameObject.transform.position = new Vector3(0f, 8 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 139.38f);
        }
        else if (player.transform.position.y > 137f && player.transform.position.y < 153.3f) //10
        {
            gameObject.transform.position = new Vector3(0f, 9 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 155.7f);
        }//
        else if (player.transform.position.y > 153.3f && player.transform.position.y < 161.9f) //11
        {
            gameObject.transform.position = new Vector3(0f, 10 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 171.5f);
        }
        else if (player.transform.position.y > 161.9f && player.transform.position.y < 185.56f) //12
        {
            gameObject.transform.position = new Vector3(0f, 11 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 187.9f);
        }
        else if (player.transform.position.y > 185.56f && player.transform.position.y < 201.8f) //13
        {
            gameObject.transform.position = new Vector3(0f, 12 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 203.9f);
        }
        else if (player.transform.position.y > 201.8f && player.transform.position.y < 218f) //14
        {
            gameObject.transform.position = new Vector3(0f, 13 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 219.5f);
        }
        else if (player.transform.position.y > 218f && player.transform.position.y < 234.1f) //15
        {
            gameObject.transform.position = new Vector3(0f, 14 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 236.3f);
        }
        else if (player.transform.position.y > 234.1f && player.transform.position.y < 250.6f) //16
        {
            gameObject.transform.position = new Vector3(0f, 15 * 16.2f, -10f);
            ps.transform.position = new Vector2(0, 252.8f);
        }
    }
}