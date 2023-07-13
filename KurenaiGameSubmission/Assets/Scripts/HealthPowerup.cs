using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.SetLoops(-1);

        sequence.Append(transform.DOPunchScale(Vector3.one * 0.2f, 0.25f, 5)).AppendInterval(0.5f);
    }
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }

    private void OnMouseDown()
    {
        Health.Instance.GainHealth();

        AudioManager.Instance.Play("Heal");

        Destroy(gameObject);
    }
}
