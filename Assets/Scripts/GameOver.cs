using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text numberLv;
    public Text countScore, countBestScore, name_panel;
    public Text score, bestScore;
    public GameObject panel;
    public AudioSource audBlock;
    // Start is called before the first frame update
    void Start()
    {
        Translate();
    }

    private void Translate()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetString("language") == "rus")
            {
                OnTranslaterRussian();
            }
            else
                if (PlayerPrefs.GetString("language") == "eng")
            {
                OnTranslaterEnglish();
            }
        }
        else
            OnTranslaterEnglish();
    }
    public void OnTranslaterRussian()
    {
        name_panel.text = "ÏÐÎÈÃÐÛØ";
        score.text = "Òåêóùèé ñ÷¸ò:";
        bestScore.text = "Ëó÷øèé ñ÷¸ò:";
    }
    public void OnTranslaterEnglish()
    {
        name_panel.text = "GAME OVER";
        score.text = "Your score:";
        bestScore.text = "Best score:";
    }
    public void InMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartBall()
    {
        Time.timeScale = 1f;
    }
    public void ActivePanelGameOver()
    {
        panel.SetActive(true);
        countScore.text = SpawnBlock.score.ToString();
        countBestScore.text = SpawnBlock.best_score.ToString();
    }
}
