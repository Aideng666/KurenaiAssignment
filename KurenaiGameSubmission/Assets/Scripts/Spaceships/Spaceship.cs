using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem explosionParticle2;
    [SerializeField] ShipTypes shipType;
    [SerializeField] float maxFallSpeed;

    float startingGravityScale;

    public ShipTypes ShipType { get { return shipType; } }

    protected Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        startingGravityScale = body.gravityScale;
    }

    protected virtual void Update()
    {
        if (body.velocity.y < -maxFallSpeed)
        {
            body.gravityScale = 0;
        }
        else
        {
            body.gravityScale = startingGravityScale;
        }

        print(body.velocity.y);
    }

    protected virtual void Hit()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);

        SpaceshipPool.Instance.AddSpaceshipToPool(gameObject);

        ScoreCounter.AddScore();
    }

    protected void OnMouseDown()
    {
        Hit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionParticle2, transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Ship"))
        {
            Hit();
            ScoreCounter.AddScore();
        }
        else if (collision.gameObject.CompareTag("Earth"))
        {
            SpaceshipPool.Instance.AddSpaceshipToPool(gameObject);
            Health.Instance.LoseHealth();
        }
    }

    protected virtual void ApplyThrusters()
    {

    }
}

public enum ShipTypes
{
    Default,
    Thruster,
    Splitter
}
