using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spaceship_Thruster : Spaceship
{
    [SerializeField] float thrusterForce;
    [SerializeField] ParticleSystem thrustParticle;
    bool hitOnce = false;

    int spinDirection = 0;

    protected override void ApplyThrusters()
    {
        Vector3 forceDirection = Quaternion.Euler(0, 0, Random.Range(-10f, 10f)) * Vector3.up;

        if (forceDirection.x < 0)
        {
            spinDirection = 1;
        }
        else if (forceDirection.x  > 0)
        {
            spinDirection = -1;
        }

        body.AddForce(forceDirection * thrusterForce, ForceMode2D.Impulse);
        transform.DOPunchScale(Vector3.up * 0.5f, 0.5f);

        Instantiate(thrustParticle, transform.position + Vector3.down, Quaternion.identity);
    }

    protected override void Update()
    {
        base.Update();

        if (hitOnce)
        {
            transform.Rotate(Vector3.forward, 0.1f * spinDirection);
        }
    }

    protected override void Hit()
    {
        if (hitOnce)
        {
            base.Hit();

            return;
        }

        hitOnce = true;

        ApplyThrusters();
    }
}
