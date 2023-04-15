using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("challengeObj game object")]
    public GameObject challengeObject;
    [Header("default spawn delay time")]
    public float spawnDelay = 1f;
    [Header("default spawn time")]
    public float spawnTime = 2f;
    public Vector3 haha;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = haha;
    }
    void InstantiateObjects()
    {
        Instantiate(challengeObject, transform.position, transform.rotation);
    }
}
