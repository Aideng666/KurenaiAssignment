using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startHealth;

    public int currentHealth { get; private set; }
    public bool gameOver { get; private set; }

    public static Health Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);

            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    private void Update()
    {
        if (currentHealth<= 0)
        {
            gameOver = true;
        }
    }

    public void LoseHealth()
    {
        currentHealth--;
    }
}
