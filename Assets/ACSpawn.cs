using UnityEngine;

public class ACSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ac_Prefab;
    private Vector3 posToSpawnOne, posToSpawnTwo;

    private int positionToSpawn;
    private int secondPositionToSpawn, secondPositionToSpawnCheck;

    private float yPos;

    [SerializeField] private int howManyToSpawn;

    private void Start()
    {
        yPos = transform.position.y;
        positionToSpawn = Random.Range(0, 5);
        //posToSpawnOne.position = Vector3.zero;

        secondPositionToSpawnCheck = Random.Range(0, 5);

        while (secondPositionToSpawnCheck != positionToSpawn)
        {
            secondPositionToSpawn = secondPositionToSpawnCheck;
            break;
        }


        if (howManyToSpawn == 1)
        {
            if (positionToSpawn == 0)
            {
                posToSpawnOne = new Vector3(-7.32f, yPos, 0);
            }
            else if (positionToSpawn == 1)
            {
                posToSpawnOne = new Vector3(-3.66f, yPos, 0);
            }
            else if (positionToSpawn == 2)
            {
                posToSpawnOne = new Vector3(0, yPos, 0);
            }
            else if (positionToSpawn == 3)
            {
                posToSpawnOne = new Vector3(3.66f, yPos, 0);
            }
            else if (positionToSpawn == 4)
            {
                posToSpawnOne = new Vector3(7.32f, yPos, 0);
            }
            SpawnBoxOne();
        }

        if (howManyToSpawn == 2)
        {
            if (positionToSpawn == 0)
            {
                posToSpawnOne = new Vector3(-7.32f, yPos, 0);
            }
            else if (positionToSpawn == 1)
            {
                posToSpawnOne = new Vector3(-3.66f, yPos, 0);
            }
            else if (positionToSpawn == 2)
            {
                posToSpawnOne = new Vector3(0, yPos, 0);
            }
            else if (positionToSpawn == 3)
            {
                posToSpawnOne = new Vector3(3.66f, yPos, 0);
            }
            else if (positionToSpawn == 4)
            {
                posToSpawnOne = new Vector3(7.32f, yPos, 0);
            }

            if (secondPositionToSpawn == 0)
            {
                posToSpawnTwo = new Vector3(-7.32f, yPos, 0);
            }
            else if (secondPositionToSpawn == 1)
            {
                posToSpawnTwo = new Vector3(-3.66f, yPos, 0);
            }
            else if (secondPositionToSpawn == 2)
            {
                posToSpawnTwo = new Vector3(0, yPos, 0);
            }
            else if (secondPositionToSpawn == 3)
            {
                posToSpawnTwo = new Vector3(3.66f, yPos, 0);
            }
            else if (secondPositionToSpawn == 4)
            {
                posToSpawnTwo = new Vector3(7.32f, yPos, 0);
            }

            SpawnBoxOne();
            SpawnBoxTwo();
        }


    }

    private void SpawnBoxOne()
    {
        Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnOne, Quaternion.identity);
    }

    private void SpawnBoxTwo()
    {
        Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnOne, Quaternion.identity);
    }
}
