using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject losePanel;
    [SerializeField] List<SpriteRenderer> hearts;

    int currentActiveHearts;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("MainTheme");
        currentActiveHearts = Health.Instance.MaxHealth;

        ScoreCounter.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + ScoreCounter.score.ToString();

        if (Health.Instance.gameOver)
        {
            AudioManager.Instance.Stop("MainTheme");

            losePanel.SetActive(true);
        }

        if (Health.Instance.currentHealth < currentActiveHearts)
        {
            hearts[currentActiveHearts - 1].transform.DOScale(0, 0.5f);

            currentActiveHearts--;
        }

        if (Health.Instance.currentHealth > currentActiveHearts)
        {
            hearts[currentActiveHearts].transform.DOScale(5, 0.5f);

            currentActiveHearts++;
        }
    }

    public void QuitGame()
    {
        SceneHandler.ChangeScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneHandler.ChangeScene("Game");
    }
}
