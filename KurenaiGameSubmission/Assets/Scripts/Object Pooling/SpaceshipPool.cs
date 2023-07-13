using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpaceshipPool : MonoBehaviour
{
    //Prefabs for spawning ships
    [SerializeField] GameObject spaceshipPrefab;
    [SerializeField] GameObject thrusterPrefab;
    [SerializeField] GameObject splitterPrefab;

    //To be able to recycle ships without destroying and reinstantiating over and over again
    Queue<GameObject> availableSpaceships;
    Queue<GameObject> availableThrusters;
    Queue<GameObject> availableSplitters;

    int totalShipsPerPool = 10;

    //Creates a singleton
    public static SpaceshipPool Instance { get; private set; }

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
        availableSpaceships = new Queue<GameObject>();
        availableThrusters = new Queue<GameObject>();
        availableSplitters = new Queue<GameObject>();

        CreatePools();
    }

    //Populates the pool for each ship type
    void CreatePools()
    {
        for (int i = 0; i < totalShipsPerPool; i++)
        {
            GameObject spaceship = Instantiate(spaceshipPrefab, transform);
            spaceship.SetActive(false);

            availableSpaceships.Enqueue(spaceship);

            GameObject thruster = Instantiate(thrusterPrefab, transform);
            thruster.SetActive(false);

            availableThrusters.Enqueue(thruster);

            GameObject splitter = Instantiate(splitterPrefab, transform);
            splitter.SetActive(false);

            availableSplitters.Enqueue(splitter);
        }
    }

    public GameObject SpawnSpaceship(ShipTypes shipType, Vector2 position)
    {
        GameObject spaceship = null;

        switch (shipType)
        {
            case ShipTypes.Default:

                if (availableSpaceships.Count == 0)
                {
                    CreatePools();
                }

                spaceship = availableSpaceships.Dequeue();

                break;

            case ShipTypes.Thruster:

                if (availableThrusters.Count == 0)
                {
                    CreatePools();
                }

                spaceship = availableThrusters.Dequeue();

                break;

            case ShipTypes.Splitter:

                if (availableSplitters.Count == 0)
                {
                    CreatePools();
                }

                spaceship = availableSplitters.Dequeue();

                break;
        }

        spaceship.SetActive(true);
        spaceship.transform.position = position;

        return spaceship;
    }

    //Despawns a spaceship and adds it back into the pool for use again later
    public void AddSpaceshipToPool(GameObject spaceship)
    {
        spaceship.SetActive(false);

        switch (spaceship.GetComponent<Spaceship>().ShipType)
        {
            case ShipTypes.Default:

                availableSpaceships.Enqueue(spaceship);

                break;

            case ShipTypes.Thruster:

                availableThrusters.Enqueue(spaceship);

                break;

            case ShipTypes.Splitter:

                availableSplitters.Enqueue(spaceship);

                break;
        }
    }
}
