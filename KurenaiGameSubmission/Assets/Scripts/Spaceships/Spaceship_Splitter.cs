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

    protected override void OnEnable()
    {
        base.OnEnable();

        hitOnce = false;
    }

    protected override void Hit()
    {
        if (hitOnce)
        {
            AudioManager.Instance.Stop("Thruster");

            base.Hit();

            SpaceshipPool.Instance.SpawnSpaceship(ShipTypes.Thruster, transform.position).GetComponent<Rigidbody2D>().AddForce(Vector3.up * 4, ForceMode2D.Impulse);

            return;
        }

        hitOnce = true;
        applyThrusters = true;

        thrustObject = Instantiate(thrustParticle, transform.position + Vector3.down, thrustParticle.transform.rotation, transform);

        AudioManager.Instance.Play("Thruster");

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
        AudioManager.Instance.Stop("Thruster");
        Destroy(thrustObject.gameObject);
    }

    protected override void ApplyThrusters()
    {
        body.AddForce(Vector3.up * thrusterForce, ForceMode2D.Force);
    }
}
