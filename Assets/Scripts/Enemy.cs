using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public static event Action EnemyKilled;

   private bool defeated = false;

   private void OnTriggerEnter(Collider other)
    {
        if (defeated ||!other.CompareTag("Player"))
        return;

        defeated = true;

        Debug.Log("Enemy killed");

        EnemyKilled?.Invoke();

        gameObject.SetActive(false);
    }
}
