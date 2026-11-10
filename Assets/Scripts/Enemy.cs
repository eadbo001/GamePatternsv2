using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip hurtSound;
   public static event Action EnemyKilled;

   private bool defeated = false;

   private void OnTriggerEnter(Collider other)
    {
        if (defeated ||!other.CompareTag("Player"))
        return;

        defeated = true;
        AudioManager.PlaySFX(hurtSound);
        Debug.Log("Enemy killed");

        EnemyKilled?.Invoke();

        gameObject.SetActive(false);
    }
}
