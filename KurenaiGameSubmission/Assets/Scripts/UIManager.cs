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

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("MainTheme");
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

        if (Health.Instance.currentHealth < hearts.Count && hearts.Count > 0)
        {
            Destroy(hearts[hearts.Count - 1].gameObject);

            hearts.RemoveAt(hearts.Count - 1);
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
