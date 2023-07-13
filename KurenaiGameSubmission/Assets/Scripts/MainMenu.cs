using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] List<Button> menuButons;
    [SerializeField] GameObject tutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("MenuTheme");

        Sequence titleTextSequence = DOTween.Sequence();

        titleTextSequence.SetLoops(1000000);

        titleTextSequence.Append(titleText.transform.DOScale(Vector3.one * 0.8f, 2f)).SetEase(Ease.InOutCubic).Append(titleText.transform.DOScale(Vector3.one, 2f)).SetEase(Ease.InOutCubic);

        Sequence buttonSequence = DOTween.Sequence();

        buttonSequence.Append(menuButons[0].transform.DOMoveX(250, 0.5f)).Append(menuButons[1].transform.DOMoveX(250, 0.5f)).Append(menuButons[2].transform.DOMoveX(250, 0.5f));
    }

    public void PlayGame()
    {
        AudioManager.Instance.Stop("MenuTheme");
        AudioManager.Instance.Play("MainTheme");

        SceneHandler.ChangeScene("Game");
    }

    public void Tutorial()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeInHierarchy);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
