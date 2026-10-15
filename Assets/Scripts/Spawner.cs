//using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ObjectToSpawn; //our prefab that we're spawning.

    private BoxCollider _spawnBox;

    //how many objects will be spawnedS
    [Range(1, 100)]
    public int numberOfObjects = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the box where we will spawn something
        _spawnBox = GetComponent<BoxCollider>();
        //loop and instatiate objects
        for(int i = 0; i < numberOfObjects; i++)
        {
           // Vector3 center = _spawnBox.center;
            Vector3 pos = new Vector3(
                Random.Range(_spawnBox.bounds.min.x, _spawnBox.bounds.max.x),
                Random.Range(_spawnBox.bounds.min.y, _spawnBox.bounds.max.y),
                Random.Range(_spawnBox.bounds.min.z, _spawnBox.bounds.max.z)
            );
            //instantiate obeject at pos with rotation and parent GemObject
            Instantiate(ObjectToSpawn, pos, ObjectToSpawn.transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
