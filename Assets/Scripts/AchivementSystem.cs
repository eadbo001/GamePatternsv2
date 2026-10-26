using UnityEngine;
using System.Collections.Generic;

public class AchivementSystem : MonoBehaviour
{
  private int totalCoinsCollected = 0;
    private int totalEnemiesKilled = 0;

    private HashSet<string> unlockedAchievements =
        new HashSet<string>();

    private void OnEnable()
    {
        Collectable.itemCollected += OnCoinCollected;
        Enemy.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        Collectable.itemCollected -= OnCoinCollected;
        Enemy.EnemyKilled -= OnEnemyKilled;
    }

    private void OnCoinCollected()
    {
        totalCoinsCollected++;

        Debug.Log("Achievement System: Coins = "
                  + totalCoinsCollected);

        if (totalCoinsCollected >= 10)
        {
            UnlockAchievement("CoinCollector");
        }
    }

    private void OnEnemyKilled()
    {
        totalEnemiesKilled++;

        Debug.Log("Achievement System: Enemies killed = "
                  + totalEnemiesKilled);

        if (totalEnemiesKilled >= 20)
        {
            UnlockAchievement("Terminator");
        }
    }

    private void UnlockAchievement(string achievementName)
    {
        // Only unlock and announce an achievement once.
        if (unlockedAchievements.Add(achievementName))
        {
            Debug.Log("ACHIEVEMENT UNLOCKED: "
                      + achievementName);
        }
    }

    public void PrintUnlockedAchievements()
    {
        Debug.Log("Unlocked achievements:");

        foreach (string achievement in unlockedAchievements)
        {
            Debug.Log(achievement);
        }

        if (unlockedAchievements.Count == 0)
        {
            Debug.Log("No achievements unlocked yet.");
        }
    }
}
