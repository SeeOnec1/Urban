using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    private bool inSpawnRange;
    [SerializeField] private float spawnRangeBottom;
    [SerializeField] private float spawnRangeTop;

    private Vector2 debrisSpawnPos;

    private bool canSpawn;
    private int delayBetweenDebris;

    [SerializeField] private GameObject playerObj;

    private void Start()
    {
        inSpawnRange = false;
        canSpawn = true;
    }

    private void Update()
    {

        transform.position =
            new Vector2(0, playerObj.transform.position.y + 30f);

        if (transform.position.y > spawnRangeBottom && transform.position.y < spawnRangeTop)
        {
            inSpawnRange = true;
        }
        else inSpawnRange = false;

        if (inSpawnRange && canSpawn)
        {
            StartCoroutine(SpawnDebris());
        }
    }

    private IEnumerator SpawnDebris()
    {
        canSpawn = false;
        delayBetweenDebris = Random.Range(5, 7);

        yield return new WaitForSeconds(delayBetweenDebris);

        int xOffset = Random.Range(0, 9);
        int direction = Random.Range(0, 2);

        if (direction == 0) { debrisSpawnPos.x = -xOffset; } //Negative Offset
        else if (direction == 1) { debrisSpawnPos.x = xOffset; } //Positve Offset

        debrisSpawnPos.y = transform.position.y;

        GameObject debris = DebrisPool._debrisInstance.GetPooledObject();

        if (debris != null)
        {
            debris.transform.position = debrisSpawnPos;
            debris.SetActive(true);
        }

        canSpawn = true;
    }
}
