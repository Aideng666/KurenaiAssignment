using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuImage : MonoBehaviour
{
    float randomRotationValue;

    private void Start()
    {
        randomRotationValue = Random.Range(-0.2f, 0.2f);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, randomRotationValue);
    }

    public void Click()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.5f, 1, 0.5f);

        randomRotationValue = Random.Range(-0.2f, 0.2f);
    }
}
