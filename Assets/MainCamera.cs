using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cmVcam;
    [SerializeField] private GameObject ps;

    [SerializeField] private float camStartPos;

    [SerializeField] private float particleStartPos;

    [SerializeField] private AudioSource fireAmb;

    private void Update()
    {
        if (player.transform.position.y < 9.21f) //1
        {
            cmVcam.transform.position = new Vector3(0f, 0f, -10f);
            ps.transform.position = new Vector2(0, particleStartPos);
        }
        else if (player.transform.position.y > 9.21f && player.transform.position.y < 29.26f) //2
        {
            cmVcam.transform.position = new Vector3(0f, 20f, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 20);
        }
        else if (player.transform.position.y > 29.26f && player.transform.position.y < 49.27f) //3
        {
            cmVcam.transform.position = new Vector3(0f, 2 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 40);
        }
        else if (player.transform.position.y > 49.27f && player.transform.position.y < 69.4f) //4
        {
            cmVcam.transform.position = new Vector3(0f, 3 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 60);
        }
        else if (player.transform.position.y > 69.4f && player.transform.position.y < 89.3f) //5
        {
            cmVcam.transform.position = new Vector3(0f, 4 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 80);
        }
        else if (player.transform.position.y > 89.3f && player.transform.position.y < 109.4f) //6
        {
            cmVcam.transform.position = new Vector3(0f, 5 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 100);
        }
        else if (player.transform.position.y > 109.4f && player.transform.position.y < 129.3f) //7
        {
            cmVcam.transform.position = new Vector3(0f, 6 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 120);
        }
        else if (player.transform.position.y > 129.3f && player.transform.position.y < 149.5f) //8
        {
            cmVcam.transform.position = new Vector3(0f, 7 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 140);
        }
        else if (player.transform.position.y > 149.5f && player.transform.position.y < 169.5f) //9
        {
            cmVcam.transform.position = new Vector3(0f, 8 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 160);
        }
        else if (player.transform.position.y > 169.5f && player.transform.position.y < 189.44f) //10
        {
            cmVcam.transform.position = new Vector3(0f, 9 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 180);
        }//
        else if (player.transform.position.y > 189.44f && player.transform.position.y < 209.5f) //11
        {
            cmVcam.transform.position = new Vector3(0f, 10 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 200);
        }
        else if (player.transform.position.y > 209.5f && player.transform.position.y < 229.5f) //12
        {
            cmVcam.transform.position = new Vector3(0f, 11 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 220);
        }
        else if (player.transform.position.y > 229.5f && player.transform.position.y < 249.5f) //13
        {
            cmVcam.transform.position = new Vector3(0f, 12 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 240);
        }
        else if (player.transform.position.y > 249.5f && player.transform.position.y < 269.5f) //14
        {
            cmVcam.transform.position = new Vector3(0f, 13 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 260);
        }
        else if (player.transform.position.y > 269.5f && player.transform.position.y < 289.6f) //15
        {
            cmVcam.transform.position = new Vector3(0f, 14 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 280);
        }
        else if (player.transform.position.y > 289.6f && player.transform.position.y < 309.5f) //16
        {
            cmVcam.transform.position = new Vector3(0f, 15 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 300);

            fireAmb.Stop();
        }
        else if (player.transform.position.y > 309.5f && player.transform.position.y < 329.61f) //17
        {
            cmVcam.transform.position = new Vector3(0f, 16 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 320);

            fireAmb.Play();
        }
        else if (player.transform.position.y > 329.61f && player.transform.position.y < 349.6f) //18
        {
            cmVcam.transform.position = new Vector3(0f, 17 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 340);
        }
        else if (player.transform.position.y > 349.6f && player.transform.position.y < 369.7f) //19
        {
            cmVcam.transform.position = new Vector3(0f, 18 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, particleStartPos + 360);
        }
        else if (player.transform.position.y > 369.7f && player.transform.position.y < 389.6f) //20
        {
            cmVcam.transform.position = new Vector3(0f, 19 * camStartPos, -10f);
            ps.transform.position = new Vector2(0, 380.94f);
        }
    }
}