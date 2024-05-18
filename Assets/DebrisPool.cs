using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPool : MonoBehaviour
{
    public static DebrisPool _debrisInstance;

    private List<GameObject> pooledDebris = new List<GameObject>();
    private int amountToPool = 2;

    [SerializeField] private GameObject debrisPrefab;

    private void Awake()
    {
        if (_debrisInstance == null)
        {
            _debrisInstance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(debrisPrefab, transform);
            obj.SetActive(false);
            pooledDebris.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledDebris.Count; i++)
        {
            if (!pooledDebris[i].activeInHierarchy)
            {
                return pooledDebris[i];
            }
        }

        return null;
    }
}
