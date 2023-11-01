using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Text name_setting;
    public GameObject btn_rus, btn_eng;
    public GameObject btn_on_vibrate, btn_off_vibrate;
    // Start is called before the first frame update
    void Start()
    {
        Translate();
        Vibrate();
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
        name_setting.text = "Настройки";
        PlayerPrefs.SetString("language", "rus");
        PlayerPrefs.Save();
        btn_rus.SetActive(true);
        btn_eng.SetActive(false);
    }
    public void OnTranslaterEnglish()
    {
        name_setting.text = "Settings";
        PlayerPrefs.SetString("language","eng");
        PlayerPrefs.Save();
        btn_rus.SetActive(false);
        btn_eng.SetActive(true);
    }
    private void Vibrate()
    {
        if (PlayerPrefs.HasKey("vibrate"))
        {
            OffVibrate();
        }
        else
        {
            OnVibrate();
        }
    }
    public void OffVibrate()
    {
        btn_on_vibrate.SetActive(false);
        btn_off_vibrate.SetActive(true);
        PlayerPrefs.SetInt("vibrate", 1);
        PlayerPrefs.Save();
    }
    public void OnVibrate()
    {
        btn_on_vibrate.SetActive(true);
        btn_off_vibrate.SetActive(false);
        if (PlayerPrefs.HasKey("vibrate"))
        {
            PlayerPrefs.DeleteKey("vibrate");
        }
    }
    public void PlayVibrate()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            Handheld.Vibrate();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
