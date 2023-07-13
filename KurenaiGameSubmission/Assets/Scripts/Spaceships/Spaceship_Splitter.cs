using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_Splitter : Spaceship
{
    [SerializeField] float thrusterForce;
    [SerializeField] ParticleSystem thrustParticle;
    bool hitOnce = false;
    bool applyThrusters;

    ParticleSystem thrustObject;

    protected override void Hit()
    {
        if (hitOnce)
        {
            base.Hit();

            SpaceshipPool.Instance.SpawnSpaceship(ShipTypes.Thruster, transform.position).GetComponent<Rigidbody2D>().AddForce(Vector3.up * 4, ForceMode2D.Impulse);

            return;
        }

        hitOnce = true;
        applyThrusters = true;

        thrustObject = Instantiate(thrustParticle, transform.position + Vector3.down, Quaternion.identity, transform);

        StartCoroutine(StopThrusters());
    }

    protected override void Update()
    {
        base.Update();

        if (applyThrusters)
        {
            ApplyThrusters();
        }
    }

    IEnumerator StopThrusters()
    {
        yield return new WaitForSeconds(0.75f);

        applyThrusters = false;

        Destroy(thrustObject);
    }

    protected override void ApplyThrusters()
    {
        body.AddForce(Vector3.up * thrusterForce, ForceMode2D.Force);
    }
}
