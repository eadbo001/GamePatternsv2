using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [Range(0.1f, 10f)]
    public float RotationSpeed = 2f;

    //Action itemCollected
    public static event Action itemCollected;

    private bool collected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (collected || !other.CompareTag("Player"))
            return;
        
        collected = true;

        Debug.Log("Player Collected a box!");

        //Invoke event notifying all observers
        //null-conditional operator ?.
        itemCollected?.Invoke();

        gameObject.SetActive(false);


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
