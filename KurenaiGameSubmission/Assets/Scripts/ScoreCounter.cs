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

        if (score % 10 == 0)
        {
            GameObject.FindObjectOfType<SpaceshipSpawner>().LowerSpawnDelay();
        }
    }
}
