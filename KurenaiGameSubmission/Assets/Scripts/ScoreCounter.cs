using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ScoreCounter
{
    public static int score { get; private set; }

    public static void AddScore()
    {
        score++;

        SpaceshipSpawner spawner = GameObject.FindObjectOfType<SpaceshipSpawner>();

        if (score % 10 == 0)
        {
            spawner.LowerSpawnDelay();
        }

        if (score % 50 == 0 && Health.Instance.currentHealth < Health.Instance.MaxHealth) 
        {
            spawner.SpawnHealthPowerup();
        }
    }
}
