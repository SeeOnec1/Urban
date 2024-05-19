using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ACSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ac_Prefab;
    private Vector3 posToSpawnOne, posToSpawnTwo, posToSpawnThree, posToSpawnFour;

    private int positionToSpawn;
    private int secondPositionToSpawn, secondPositionToSpawnCheck, thirdPositionToSpawnCheck, thirdPositionToSpawn, fourPositionToSpawnCheck, fourPositionToSpawn;

    private float yPos;

    [SerializeField] private int howManyToSpawn = 1;

    [SerializeField] private float xOne;
    [SerializeField] private float xTwo;

    private void Start()
    {
        yPos = transform.position.y;
        positionToSpawn = Random.Range(0, 5);
        //posToSpawnOne.position = Vector3.zero;

        secondPositionToSpawnCheck = Random.Range(0, 5);
        secondPositionToSpawn = secondPositionToSpawnCheck;

        thirdPositionToSpawnCheck = Random.Range(0, 5);
        thirdPositionToSpawn = thirdPositionToSpawnCheck;

        fourPositionToSpawnCheck = Random.Range(0, 5);
        fourPositionToSpawn = fourPositionToSpawnCheck;

        if (secondPositionToSpawn == positionToSpawn)
        {
            secondPositionToSpawnCheck = Random.Range(0, 5);
            secondPositionToSpawn = secondPositionToSpawnCheck;
        }

        if (thirdPositionToSpawn == positionToSpawn || thirdPositionToSpawn == secondPositionToSpawn)
        {
            thirdPositionToSpawnCheck = Random.Range(0, 5);
            thirdPositionToSpawn = thirdPositionToSpawnCheck;
        }

        while (fourPositionToSpawn == positionToSpawn || fourPositionToSpawn == secondPositionToSpawn || fourPositionToSpawn == thirdPositionToSpawn)
        {
            fourPositionToSpawnCheck = Random.Range(0, 5);
            fourPositionToSpawn = fourPositionToSpawnCheck;
        }


        /*
        while (secondPositionToSpawnCheck == positionToSpawn)
        {
            secondPositionToSpawn = secondPositionToSpawnCheck;
            break;
        }

        while (thirdPositionToSpawnCheck != positionToSpawn && thirdPositionToSpawnCheck != secondPositionToSpawn)
        {
            thirdPositionToSpawn = thirdPositionToSpawnCheck;
            break;
        }*/
        if (positionToSpawn == 0)
        {
            posToSpawnOne = new Vector3(-xTwo, yPos, 0);
        }
        else if (positionToSpawn == 1)
        {
            posToSpawnOne = new Vector3(-xOne, yPos, 0);
        }
        else if (positionToSpawn == 2)
        {
            posToSpawnOne = new Vector3(0, yPos, 0);
        }
        else if (positionToSpawn == 3)
        {
            posToSpawnOne = new Vector3(xOne, yPos, 0);
        }
        else if (positionToSpawn == 4)
        {
            posToSpawnOne = new Vector3(xTwo, yPos, 0);
        }

        if (secondPositionToSpawn == 0)
        {
            posToSpawnTwo = new Vector3(-xTwo, yPos, 0);
        }
        else if (secondPositionToSpawn == 1)
        {
            posToSpawnTwo = new Vector3(-xOne, yPos, 0);
        }
        else if (secondPositionToSpawn == 2)
        {
            posToSpawnTwo = new Vector3(0, yPos, 0);
        }
        else if (secondPositionToSpawn == 3)
        {
            posToSpawnTwo = new Vector3(xOne, yPos, 0);
        }
        else if (secondPositionToSpawn == 4)
        {
            posToSpawnTwo = new Vector3(xTwo, yPos, 0);
        }

        if (thirdPositionToSpawn == 0)
        {
            posToSpawnThree = new Vector3(-xTwo, yPos, 0);
        }
        else if (thirdPositionToSpawn == 1)
        {
            posToSpawnThree = new Vector3(-xOne, yPos, 0);
        }
        else if (thirdPositionToSpawn == 2)
        {
            posToSpawnThree = new Vector3(0, yPos, 0);
        }
        else if (thirdPositionToSpawn == 3)
        {
            posToSpawnThree = new Vector3(xOne, yPos, 0);
        }
        else if (thirdPositionToSpawn == 4)
        {
            posToSpawnThree = new Vector3(xTwo, yPos, 0);
        }

        if (fourPositionToSpawn == 0)
        {
            posToSpawnFour = new Vector3(-xTwo, yPos, 0);
        }
        else if (fourPositionToSpawn == 1)
        {
            posToSpawnFour = new Vector3(-xOne, yPos, 0);
        }
        else if (fourPositionToSpawn == 2)
        {
            posToSpawnFour = new Vector3(0, yPos, 0);
        }
        else if (fourPositionToSpawn == 3)
        {
            posToSpawnFour = new Vector3(xOne, yPos, 0);
        }
        else if (fourPositionToSpawn == 4)
        {
            posToSpawnFour = new Vector3(xTwo, yPos, 0);
        }


        if (howManyToSpawn == 1)
        {
            SpawnBoxOne();
        }

        if (howManyToSpawn == 2)
        {
            SpawnBoxOne();
            SpawnBoxTwo();
        }

        if (howManyToSpawn == 3)
        {
            SpawnBoxOne();
            SpawnBoxTwo();
            SpawnBoxThree();
        }

        if (howManyToSpawn == 4)
        {
            SpawnBoxOne();
            SpawnBoxTwo();
            SpawnBoxThree();
            SpawnBoxFour();
        }
    }

    private void SpawnBoxOne()
    {
        //Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnOne, Quaternion.identity);
    }

    private void SpawnBoxTwo()
    {
        //Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnTwo, Quaternion.identity);
    }

    private void SpawnBoxThree()
    {
        //Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnThree, Quaternion.identity);
    }

    private void SpawnBoxFour()
    {
        //Debug.Log("ahhhhhhhhhhhhhhhhhhh");
        Instantiate(ac_Prefab, posToSpawnFour, Quaternion.identity);
    }
}
