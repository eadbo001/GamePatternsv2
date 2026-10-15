using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [Range(0.1f, 10f)]
    public float RotationSpeed = 2f;

    //Action itemCollected
    public static event Action itemCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Collected");
            //notify all observers
            itemCollected?.Invoke();
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate
        transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed * 360f, Space.World);
    }
}
